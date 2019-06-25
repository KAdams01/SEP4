using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using InputTracking = UnityEngine.XR.InputTracking;
using Node = UnityEngine.XR.XRNode;


public class LocalPlayerControl : NetworkBehaviour
{
    public GameObject ovrCamRig;
    public Transform leftHand;
    public Transform rightHand;
    public Camera leftEye;
    public Camera rightEye;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            Destroy(ovrCamRig);
        }

        else
        {
            //Takes care of camera when other player joins the scene
            if(leftEye.tag != "MainCamera")
            {
                leftEye.tag = "MainCamera";
                leftEye.enabled = true;
            }

            if (rightEye.tag != "MainCamera")
            {
                rightEye.tag = "MainCamera";
                rightEye.enabled = true;
            }

            //Takes care of hand position tracking
            leftHand.localPosition = InputTracking.GetLocalPosition(Node.LeftHand);
            leftHand.localRotation = InputTracking.GetLocalRotation(Node.LeftHand);

            rightHand.localPosition = InputTracking.GetLocalPosition(Node.RightHand);
            rightHand.localRotation = InputTracking.GetLocalRotation(Node.RightHand);

            //Handles position and rotation of player
            Vector2 primaryAxis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            if (primaryAxis.y > 0f)
            {
                position += (primaryAxis.y * transform.forward * Time.deltaTime);
            }

            if (primaryAxis.y < 0f)
            {
                position += (Mathf.Abs(primaryAxis.y) * -transform.forward * Time.deltaTime);
            }

            if (primaryAxis.x > 0f)
            {
                position += (primaryAxis.x * transform.right * Time.deltaTime);
            }

            if (primaryAxis.x < 0f)
            {
                position += (Mathf.Abs(primaryAxis.x) * -transform.right * Time.deltaTime);
            }

            transform.position = position;

            Vector3 euler = transform.rotation.eulerAngles;
            Vector2 secondaryAxis = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
            euler.y = secondaryAxis.x;
            transform.rotation = Quaternion.Euler(euler);

            //Maybe set local rotation too?
            transform.localRotation = Quaternion.Euler(euler);
        }
    }
}
