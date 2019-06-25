using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScopeZoomLevel : MonoBehaviour
{
    [SerializeField] private Camera scopeCamera;
    [SerializeField] private float stepDistance;
    [HideInInspector]
    public float currentZoomLevel;
    [SerializeField]
    private float minScopeDistance;
    [SerializeField]
    private float maxScopeDistance;
    [SerializeField]
    private float zoomOffsetAngle;
    private void Update()
    {
        if(scopeCamera.fieldOfView != currentZoomLevel)
        {
            currentZoomLevel = scopeCamera.fieldOfView;
        }
    }
    public void ZoomIn()
    {
        if (scopeCamera.fieldOfView > maxScopeDistance)
        {
            scopeCamera.fieldOfView -= stepDistance;
            scopeCamera.transform.Rotate(zoomOffsetAngle, 0, 0);
        }

    }

    public void ZoomOut()
    {
        if (scopeCamera.fieldOfView < minScopeDistance)
        {
            scopeCamera.fieldOfView += stepDistance;
            scopeCamera.transform.Rotate(-zoomOffsetAngle, 0, 0);
        }
    }


}
