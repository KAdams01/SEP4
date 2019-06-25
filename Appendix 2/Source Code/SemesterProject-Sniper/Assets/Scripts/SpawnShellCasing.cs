using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnShellCasing : MonoBehaviour
{
    [SerializeField] private GameObject ShellCasing;
    [SerializeField] private Transform spawnLocation;
    private Random randomNumber;

	// Use this for initialization
	void Start ()
    {
        randomNumber = new Random();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnShellCasingAtLoc()
    {
        GameObject casing = Instantiate(ShellCasing, spawnLocation.position, spawnLocation.rotation);
        casing.transform.Rotate(90,0,0);
        Rigidbody casingRB = casing.GetComponent<Rigidbody>();
        
        float random1 = randomNumber.Next(0,50);
        float random2 = randomNumber.Next(-20, 20);
        float random3 = randomNumber.Next(-20, 20);
        Vector3 direction = new Vector3(random1, random2, random3);
        casingRB.AddForce(direction);
    }
}
