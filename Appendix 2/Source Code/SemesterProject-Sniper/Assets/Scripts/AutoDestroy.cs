using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {
    public float destroyBelowY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y < destroyBelowY)
        {
            Destroy(gameObject);
        }
	}
    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.gameObject.tag == "Target")
        {
            Destroy(gameObject);
        }
    }
}
