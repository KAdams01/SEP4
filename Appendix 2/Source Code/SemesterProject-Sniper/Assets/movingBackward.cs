using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingBackward : MonoBehaviour
{

    public GameObject target;
    public GameObject endPoint;
    private float maxPosition;
    private void Start()
    {
        maxPosition = endPoint.transform.position.x + 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SniperRifle"))
        {
            if (maxPosition > target.transform.position.x)
            {
                target.transform.Translate(Vector3.right * 300f * Time.deltaTime, Space.World);
                GameObject[] bulletHoles = GameObject.FindGameObjectsWithTag("BulletHole");
                foreach (GameObject g in bulletHoles)
                {
                    g.transform.Translate(Vector3.left * 300f * Time.deltaTime, Space.World);
                }
                
            }
        }
    }
}
