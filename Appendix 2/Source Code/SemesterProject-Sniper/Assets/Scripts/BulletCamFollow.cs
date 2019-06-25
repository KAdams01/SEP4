using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCamFollow : MonoBehaviour
{
    //[SerializeField] private GameObject objectToFollow;

    //[SerializeField] private float distanceFromObject;

    public Transform bulletTransform;

    private Vector3 offset;

    void Start()
    {
        bulletTransform = GameObject.FindGameObjectWithTag("Bullet").transform;
    }

    void LateUpdate()
    {
        if (bulletTransform == null)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = new Vector3(bulletTransform.position.x, bulletTransform.position.y, bulletTransform.position.z - 0.3f);
        }
    }
}
