using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision with " + gameObject.name + " at x:" + collider.gameObject.transform.position.x + ", y: " + collider.gameObject.transform.position.y + ", z: " + collider.gameObject.transform.position.z);
    }
}
