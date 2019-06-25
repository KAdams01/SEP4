using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScoreChecker : MonoBehaviour
{
    private ScoreManager scoreMan;
    // Start is called before the first frame update
    void Start()
    {
        scoreMan = ScoreManager.Instance;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.gameObject.name)
        {
            case "10Points":
                AddToScore(10);
                break;
            case "9Points":
                AddToScore(9);
                break;
            case "8Points":
                AddToScore(8);
                break;
            case "7Points":
                AddToScore(7);
                break;
            case "6Points":
                AddToScore(6);
                break;
            case "5Points":
                AddToScore(5);
                break;
            case "4Points":
                AddToScore(4);
                break;
            case "3Points":
                AddToScore(3);
                break;
            case "2Points":
                AddToScore(2);
                break;
            case "1Point":
                AddToScore(1);
                break;
            default:
                break;
        }
    }
    private void AddToScore(float score)
    {
        scoreMan.IncrementScore(score);
    }
}
