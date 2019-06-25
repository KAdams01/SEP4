using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarTargetState : MonoBehaviour, iGameState
{
    private SoundManager sm;
    private bool isStarted;
    public static bool farTargetHit;
    public AudioClip farTarget;
    public void TransitionToNextState()
    {
        Debug.Log("Transitioning to Outro State");
        GameStateManager.gameState = GameState.Outro;
    }

    // Start is called before the first frame update
    void Start()
    {
        sm = SoundManager.Instance;
        isStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.gameState == GameState.FarTarget && !isStarted)
        {
            isStarted = true;
            StartCoroutine(Initiate());
        }
        if (GameStateManager.gameState == GameState.FarTarget && farTargetHit)
        {
            TransitionToNextState();
        }
    }
    IEnumerator Initiate()
    {
        yield return new WaitForSeconds(1);
        sm.PlayAudioClip(farTarget);
        yield return new WaitForSeconds(farTarget.length + 1);

    }
}
