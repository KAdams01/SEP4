using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseting : MonoBehaviour
{
    private ScoreManager scoreMan;
    // Start is called before the first frame update
    void Start()
    {
        scoreMan = ScoreManager.Instance;
    }

    // Update is called once per frames
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SniperRifle"))
        {
            scoreMan.mainScore = 0;
            GameObject[] bulletHoles = GameObject.FindGameObjectsWithTag("BulletHole");
            foreach(GameObject g in bulletHoles)
            {
                Destroy(g);
            }
        }
    }
}
