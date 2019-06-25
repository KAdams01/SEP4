using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearTargetCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("First Target colliding");
        if (collision.collider.gameObject.tag == "Bullet")
        {
            NearTargetState.nearTargetHit = true;
        }
    }
}
