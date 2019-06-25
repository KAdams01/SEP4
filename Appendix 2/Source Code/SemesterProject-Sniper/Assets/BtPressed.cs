using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtPressed : MonoBehaviour
{
    [SerializeField] private Animator anim1;

    private void OnTriggerEnter(Collider other)
    { 
      if (other.CompareTag("SniperRifle"))
        {
            anim1.SetBool("playSpin",true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SniperRifle"))
        {
            anim1.SetBool("playSpin", false);
        }
    
    }
    
}
