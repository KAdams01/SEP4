using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenPoints : MonoBehaviour
{
    private ScoreManager scoreMan;
    // Start is called before the first frame update
    void Start()
    {
        scoreMan = ScoreManager.Instance;
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Bullet")
        {
            scoreMan.IncrementScore(10f);
        }
    }
}
