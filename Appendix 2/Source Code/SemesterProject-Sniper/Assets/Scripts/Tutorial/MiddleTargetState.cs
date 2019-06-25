using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleTargetState : MonoBehaviour, iGameState
{
    private SoundManager sm;
    private bool isStarted;
    [HideInInspector]
    public static bool middleTargetHit;
    public AudioClip middleTarget;
    public void TransitionToNextState()
    {
        Debug.Log("Transitioning to Far Target State");
        GameStateManager.gameState = GameState.FarTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        sm = SoundManager.Instance;
        isStarted = false;
        middleTargetHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.gameState == GameState.MiddleTarget && !isStarted)
        {
            isStarted = true;
            StartCoroutine(Initiate());
        }
        if (GameStateManager.gameState == GameState.MiddleTarget && middleTargetHit)
        {
            TransitionToNextState();
        }
    }
    IEnumerator Initiate()
    {
        yield return new WaitForSeconds(1);
        sm.PlayAudioClip(middleTarget);
        yield return new WaitForSeconds(middleTarget.length + 1);

    }
}
