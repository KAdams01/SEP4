using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleTargetCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Second Target colliding");
        if (collision.collider.gameObject.tag == "Bullet" && NearTargetState.nearTargetHit)
        {
            MiddleTargetState.middleTargetHit = true;
        }
    }
}
