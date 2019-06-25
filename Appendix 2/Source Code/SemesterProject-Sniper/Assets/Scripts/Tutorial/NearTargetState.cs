using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearTargetState : MonoBehaviour, iGameState
{
    private SoundManager sm;
    private bool isStarted;
    public static bool nearTargetHit;

    public void TransitionToNextState()
    {
        Debug.Log("Transitioning to Middle Target State");
        GameStateManager.gameState = GameState.MiddleTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        sm = SoundManager.Instance;
        isStarted = false;
        nearTargetHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.gameState == GameState.NearTarget && !isStarted)
        {
            isStarted = true;
        }
        if (GameStateManager.gameState == GameState.NearTarget && nearTargetHit)
        {
            StartCoroutine(Initiate());
        }
    }
    IEnumerator Initiate()
    {
        yield return new WaitForSeconds(1);
        TransitionToNextState();
    }
}
