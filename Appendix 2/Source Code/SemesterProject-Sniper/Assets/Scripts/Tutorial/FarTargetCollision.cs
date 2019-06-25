using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarTargetCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Third Target colliding");
        if (collision.collider.gameObject.tag == "Bullet" && MiddleTargetState.middleTargetHit)
        {
            FarTargetState.farTargetHit = true;
        }
    }
}
