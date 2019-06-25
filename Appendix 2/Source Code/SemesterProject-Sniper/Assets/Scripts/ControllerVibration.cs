using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ControllerVibration
{
    public static void EnableVibration(float frequency, float amplitude)
    {
        OVRInput.SetControllerVibration(frequency, amplitude, OVRInput.Controller.RTouch);
    }

    public static void DisableVibration()
    {
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
    }
}
