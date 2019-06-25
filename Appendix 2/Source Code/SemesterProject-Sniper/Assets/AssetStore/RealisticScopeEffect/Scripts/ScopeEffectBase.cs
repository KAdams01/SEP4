namespace ScopeEffect
{
    using UnityEngine;

    public class ScopeEffectBase : MonoBehaviour
    {
        public Material material;
        public GameObject cameraObject;
        public bool showSceneDebugRays;

        void LateUpdate()
        {
            Vector3 dirFromCamToScope = transform.InverseTransformDirection(transform.position - cameraObject.transform.position).normalized;

            Vector3 dir1y = dirFromCamToScope;
            dir1y.z = 0;
            dir1y = transform.TransformDirection(dir1y);

            Vector3 dir2 = transform.TransformDirection(Vector3.right);

            float yAngle = Vector3.SignedAngle(dir1y, dir2, transform.TransformDirection(Vector3.forward));

            Vector3 dir1x = dirFromCamToScope;
            dir1x.y = 0;
            dir1x = transform.TransformDirection(dir1x);

            float xAngle = Vector3.SignedAngle(dir1x, dir2, transform.TransformDirection(Vector3.up));

            float distance = Vector3.Distance(transform.position, cameraObject.transform.position);

            material.SetFloat("_CameraDistance", distance);
            material.SetFloat("_XOffset", xAngle);
            material.SetFloat("_YOffset", yAngle);

            if (showSceneDebugRays)
            {
                float eyeReliefDistance = material.GetFloat("_EyeReliefDistance");

                Debug.DrawLine(Vector3.Lerp(transform.position, cameraObject.transform.position, eyeReliefDistance / distance), transform.position, Color.yellow);
                Debug.DrawLine(Vector3.Lerp(transform.position, cameraObject.transform.position, eyeReliefDistance / distance), cameraObject.transform.position, Color.black);
                Debug.DrawLine(transform.position, transform.position + dir1y.normalized * 5, Color.green);
                Debug.DrawLine(transform.position, transform.position + dir1x.normalized * 5, Color.red);
                Debug.DrawLine(transform.position, transform.position + dir2.normalized * 5, Color.blue);
            }
        }
    }
}