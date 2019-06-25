using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerIntroTwo : MonoBehaviour, iGameState
{
    private bool isStarted;
    private SoundManager sm;
    public AudioClip beforeILetYou;
    public ScopeZoomLevel sZL;
    private bool awaitingPlayerInput;
    public AudioClip zoomComplete;
    public void TransitionToNextState()
    {
        Debug.Log("Transitioning to MovingTargetState State");
        GameStateManager.gameState = GameState.TargetIntro;
    }

    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
        sm = SoundManager.Instance;
        awaitingPlayerInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.gameState == GameState.ControllerIntroTwo && !isStarted)
        {
            isStarted = true;
            StartCoroutine(Initiate());
        }
        if (GameStateManager.gameState == GameState.ControllerIntroTwo && awaitingPlayerInput)
        {
            if(sZL.currentZoomLevel == 1)
            {
                awaitingPlayerInput = false;
                StartCoroutine(Completion());
            }
        }
    }
    IEnumerator Initiate()
    {
        yield return new WaitForSeconds(1);
        sm.PlayAudioClip(beforeILetYou);
        yield return new WaitForSeconds(beforeILetYou.length + 1);
        awaitingPlayerInput = true;

    }
    IEnumerator Completion() {
        sm.PlayAudioClip(zoomComplete);
        yield return new WaitForSeconds(zoomComplete.length + 1);
        TransitionToNextState();
    }
}
