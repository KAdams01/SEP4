﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isTouchingWorks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("DUNAI!!!!");
        Debug.Log(transform.position.x + " " + transform.position.y + " " + transform.position.z);


    

    }
}
