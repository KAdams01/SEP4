using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderInfo : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collided with: " + col.collider.name);
    }
}
