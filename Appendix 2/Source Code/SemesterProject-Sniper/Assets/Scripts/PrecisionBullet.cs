using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrecisionBullet : MonoBehaviour {
    public static void Heuns(
        float h,
        Vector3 currentPosition,
        Vector3 currentVelocity,
        out Vector3 newPosition,
        out Vector3 newVelocity)
    {
        //Init acceleration
        //Gravity
        Vector3 acceleartionFactorEuler = Physics.gravity;
        Vector3 acceleartionFactorHeun = Physics.gravity;


        //Init velocity
        //Current velocity
        Vector3 velocityFactor = currentVelocity;
        //Wind velocity
        //velocityFactor += new Vector3(2f, 0f, 3f);


        //
        //Main algorithm
        //
        //Euler forward
        Vector3 pos_E = currentPosition + h * velocityFactor;

        //acceleartionFactorEuler += CalculateDrag(currentVelocity);

        Vector3 vel_E = currentVelocity + h * acceleartionFactorEuler;


        //Heuns method
        Vector3 pos_H = currentPosition + h * 0.5f * (velocityFactor + vel_E);

        //acceleartionFactorHeun += CalculateDrag(vel_E);

        Vector3 vel_H = currentVelocity + h * 0.5f * (acceleartionFactorEuler + acceleartionFactorHeun);


        newPosition = pos_H;
        newVelocity = vel_H;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
