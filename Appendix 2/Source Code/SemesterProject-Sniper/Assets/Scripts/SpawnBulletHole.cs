using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBulletHole : MonoBehaviour
{
    [SerializeField] private GameObject bulletHoleImage;
    

	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {

       

    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("istouched");
        GameObject bulletHole = Instantiate(bulletHoleImage, new Vector3(col.contacts[0].point.x-0.0025f, col.contacts[0].point.y-0.0025f, col.contacts[0].point.z-0.001f), Quaternion.LookRotation(col.contacts[0].normal));
        bulletHole.transform.position -= bulletHole.transform.forward * 0.005f;
       
    }
}
