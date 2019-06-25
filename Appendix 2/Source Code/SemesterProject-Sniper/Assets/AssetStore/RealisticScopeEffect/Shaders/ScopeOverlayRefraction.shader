Shader "Custom/Scope Overlay Refraction"
{
	Properties
	{	
	    [Header(Main Texture)]
	    [Space(10)]
		_Color("    Main Color", Color) = (1, 1, 1, 1)
		_SpecColor("    Specular Color", Color) = (1, 1, 1, 1)
		_Smoothness("    Smoothness", Range(0, 1)) = 1
		_Metallic("    Metallic", Range(0, 1)) = 0
		_MainTex("    Main Texture", 2D) = "white" {}    
		[Normal]
		_BumpMap("    Normalmap", 2D) = "bump" {}
		_NormSmoothness("    Normal Smoothness", Range(0, 1)) = 1
		_ParallaxMap("    Heightmap", 2D) = "bump" {}
		[Normal]
		_Parallax("    Height", Range(0.005, 10)) = 0.02
		[Space(10)]
		[Header(Reticle Overlay)]
		[Space(10)]
		_DecalReticle("    Decal - Reticle Overlay", 2D) = "white" {}
		_DecalReticleSmoothness("    Reticle Reflection", Range(0, 1)) = 1
		[Space(10)]
		[Header(Shadow Overlay)]
		[Space(10)]
		_DecalShadow("    Decal - Parallax Shadow Overlay", 2D) = "white" {}	
		_DecalShadowSmoothness("    Parallax Shadow Reflection", Range(0, 1)) = 1
		[Space(10)]
		[Header(Parallax Offsets)]
		[Space(10)]
		_EyeReliefDistance("    Eye Relief Distance", Float) = 0.5
		_EyeReliefNoBlurZone("    No Blur Zone", Float) = 0.2
		_ScopePictureBlurMultiplier("    Scope Blur Multiplier", Float) = 0.01		
		_MainTexOffsetMultiplier("    Main Texture Offset Multiplier", Float) = 0.01
		_ReticleOffsetMultiplier("    Reticle Offset Multiplier", Float) = 0.02
		_ShadowOffsetMultiplier("    Parallax Shadow Offset Multiplier", Float) = 0.05
		_ShadowScaleMultiplier("    Parallax Shadow Scale Multiplier", Float) = 0.5
		_RefractionFadeInStart("    Refraction Fade-In Start angle", Float) = 7
		_RefractionFadeInEnd("    Refraction Fade-In End angle", Float) = 100
		[Space(5)]
		_CameraDistance("    Camera Distance (Set via script)", Float) = 1
		[Space(5)]
		_XOffset("    X Offset (Set via script)", Float) = 0
		_YOffset("    Y Offset (Set via script)", Float) = 0	
	}

	SubShader
	{
		ColorMask RGB
		Cull Off

		Tags{"RenderType" = "Opaque" }
		LOD 600

		CGPROGRAM
		#pragma surface surf Standard noshadow
		#pragma target 3.0

		sampler2D _MainTex;
		UNITY_DECLARE_TEX2D(_DecalReticle);
		UNITY_DECLARE_TEX2D_NOSAMPLER (_DecalShadow);
		UNITY_DECLARE_TEX2D_NOSAMPLER (_BumpMap);
		UNITY_DECLARE_TEX2D_NOSAMPLER (_ParallaxMap);
		half4 _Color;
		fixed _Parallax;
		fixed _Shininess;
		fixed _MainTexOffsetMultiplier;
		fixed _ShadowOffsetMultiplier;
		fixed _ShadowScaleMultiplier;
		fixed _ReticleOffsetMultiplier;
		fixed _CameraDistance;
		fixed _XOffset;
		fixed _YOffset;
		fixed _NormSmoothness;
		fixed _EyeReliefDistance;
		fixed _EyeReliefNoBlurZone;
		fixed _ScopePictureBlurMultiplier;
		fixed _DecalReticleSmoothness;
		fixed _DecalShadowSmoothness;
		fixed _DecalShadowDistanceScale;
		fixed _Smoothness;
		fixed _Metallic;	

		struct Input 
		{
			float2 uv_MainTex;
			float2 uv_ParallaxMap;
			float2 uv_DecalReticle;
			float2 uv_DecalShadow;
			float2 uv_BumpMap;
			float3 viewDir;
		};

		float normpdf(float x, float sigma)
		{
			return 0.39894*exp(-0.5*x*x / (sigma*sigma)) / sigma;
		}

		half4 blur(sampler2D tex, float2 uv, float blurAmount) 
		{
			half4 col = tex2D(tex, uv);
			const int mSize = 11;
			const int iter = (mSize - 1) / 2;
			for (int i = -iter; i <= iter; ++i) {
				for (int j = -iter; j <= iter; ++j) {
					col += tex2D(tex, float2(uv.x + i * blurAmount, uv.y + j * blurAmount)) * normpdf(float(i), 7);
				}
			}

			return col / mSize;
		}

		void surf(Input IN, inout SurfaceOutputStandard o) 
		{
			half4 norm = UNITY_SAMPLE_TEX2D_SAMPLER(_BumpMap, _DecalReticle, (IN.uv_BumpMap));
			norm.r = (0.5 * (1 - _NormSmoothness)) + (norm.r * _NormSmoothness);
			norm.g = (0.5 * (1 - _NormSmoothness)) + (norm.g * _NormSmoothness);
			norm.b = (1 - _NormSmoothness) + (norm.b * _NormSmoothness);
			norm.a = (0.5 * (1 - _NormSmoothness)) + (norm.a * _NormSmoothness);
			half3 normFinal = UnpackNormal(norm).rgb;

			float scale = pow(_CameraDistance + 1 - _EyeReliefDistance, _ShadowScaleMultiplier / _EyeReliefDistance);

			IN.uv_DecalShadow *= float2(scale, scale);
			IN.uv_DecalShadow += float2((1 - scale) / 2, (1 - scale) / 2);
			IN.uv_DecalShadow = float2(IN.uv_DecalShadow.x + (_XOffset * _ShadowOffsetMultiplier * scale), IN.uv_DecalShadow.y + (_YOffset * _ShadowOffsetMultiplier * scale));

			half h = UNITY_SAMPLE_TEX2D_SAMPLER(_ParallaxMap, _DecalReticle, IN.uv_ParallaxMap).w;
			float2 offset = ParallaxOffset(h, _Parallax, IN.viewDir);
			
			IN.uv_DecalShadow += offset;
			half4 DecalShadow = UNITY_SAMPLE_TEX2D_SAMPLER(_DecalShadow, _DecalReticle, IN.uv_DecalShadow);

			IN.uv_DecalReticle += offset;
			IN.uv_DecalReticle = float2(IN.uv_DecalReticle.x + (_XOffset * -_ReticleOffsetMultiplier), IN.uv_DecalReticle.y + (_YOffset * -_ReticleOffsetMultiplier));
			half4 reticle = UNITY_SAMPLE_TEX2D(_DecalReticle, IN.uv_DecalReticle);

			IN.uv_MainTex += offset;
			IN.uv_MainTex = float2(IN.uv_MainTex.x + (_XOffset * -_MainTexOffsetMultiplier), IN.uv_MainTex.y + (_YOffset * -_MainTexOffsetMultiplier));
			half4 tex = blur(_MainTex, IN.uv_MainTex, clamp(abs(_CameraDistance - _EyeReliefDistance) - (_EyeReliefNoBlurZone / 2), 0, 1) * _ScopePictureBlurMultiplier);
			half4 c = tex * _Color;

			half oneMinusDecalShadowAlpha = 1 - DecalShadow.a;
			half oneMinusReticleAlpha = 1 - reticle.a;

			o.Albedo = (c.rgb * c.a * oneMinusDecalShadowAlpha * oneMinusReticleAlpha) + (DecalShadow.rgb * DecalShadow.a) +(reticle.rgb * reticle.a * oneMinusDecalShadowAlpha);
			o.Emission = c.rgb * oneMinusReticleAlpha * oneMinusDecalShadowAlpha * _SpecColor;

			o.Alpha = c.a;
			o.Normal = normFinal;
			o.Smoothness = (_Smoothness * oneMinusDecalShadowAlpha * _DecalReticleSmoothness) + (_Smoothness * DecalShadow.a * _DecalShadowSmoothness);
			o.Metallic = _Metallic;
		}

		ENDCG

		GrabPass
		{
			"_Pass1"
		}

		Pass
		{
			CGPROGRAM

			#pragma vertex vert  
			#pragma fragment frag 
			#include "UnityCG.cginc"

			struct vertInput 
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct vertOutput 
			{
				float4 pos : SV_POSITION;
				float3 normalDir : TEXCOORD0;
				float4 grabPos : TEXCOORD2;
				float3 viewDir : TEXCOORD1;
			};

			vertOutput vert(vertInput input)
			{
				vertOutput output;

				float4x4 modelMatrix = unity_ObjectToWorld;
				float4x4 modelMatrixInverse = unity_WorldToObject;

				output.viewDir = mul(modelMatrix, input.vertex).xyz - _WorldSpaceCameraPos;
				output.normalDir = normalize(mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
				output.pos = UnityObjectToClipPos(input.vertex);
				output.grabPos = ComputeGrabScreenPos(UnityObjectToClipPos(input.vertex));

				return output;
			}

			sampler2D _Pass1;
			fixed _XOffset;
			fixed _YOffset;
			fixed _RefractionFadeInStart;
			fixed _RefractionFadeInEnd;

			float4 frag(vertOutput input) : COLOR
			{
				float refractiveIndex = 1.5;
				float3 refractedDir = refract(normalize(input.viewDir),
				normalize(input.normalDir), 1.0 / refractiveIndex);
				fixed maxAngle = clamp(max(abs(_XOffset), abs(_YOffset)) - _RefractionFadeInStart, 0, 90) * (90 / (_RefractionFadeInEnd - _RefractionFadeInStart));
				maxAngle /= 90;

				return ((tex2Dproj(_Pass1, input.grabPos) * (1 - maxAngle)) + (UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, refractedDir) * maxAngle));
			}
			ENDCG
		}
	}
	FallBack "Standard"
}