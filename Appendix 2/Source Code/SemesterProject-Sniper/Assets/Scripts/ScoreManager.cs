using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance = null;
    public float mainScore;



    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)
        {
            //if not, set instance to this
            Instance = this;
        }
        //If instance already exists and it's not this:
        else if (Instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        mainScore = 0;
    }

    public void IncrementScore(float score)
    {
        mainScore += score;
        Debug.Log("Score: " + mainScore);
    }
    public void DecrementScore(float score)
    {
        mainScore -= score;
    }
}
