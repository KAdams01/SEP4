using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPosition : MonoBehaviour
{
    public Transform centerEyeAnchor;
    public float distanceFromCamera;

    // Update is called once per frame
    void Update()
    {
        Vector3 finalPosition = centerEyeAnchor.position + centerEyeAnchor.forward * distanceFromCamera;
        transform.position = finalPosition;
        transform.LookAt(centerEyeAnchor);
    }
}
