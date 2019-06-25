using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingForward : MonoBehaviour
{

    public GameObject target;

    private float initialPosition;

    private void Start()
    {
        initialPosition = target.transform.position.x + 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SniperRifle"))
        {
            if (target.transform.position.x > initialPosition)

            target.transform.Translate(Vector3.left * 300f * Time.deltaTime, Space.World);
            GameObject[] bulletHoles = GameObject.FindGameObjectsWithTag("BulletHole");
            foreach (GameObject g in bulletHoles)
            {
                g.transform.Translate(Vector3.left * 300f * Time.deltaTime, Space.World);
            }
        }
    }
}