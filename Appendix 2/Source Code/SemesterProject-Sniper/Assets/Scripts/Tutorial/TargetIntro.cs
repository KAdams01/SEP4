using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIntro : MonoBehaviour, iGameState
{
    private bool isStarted;

    private bool waitingForPlayerAction = false;
    private SoundManager sm;
    public AudioClip onToShooting;
    public void TransitionToNextState()
    {
        Debug.Log("Transitioning to Near Target State");
        GameStateManager.gameState = GameState.NearTarget;
    }

    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
        sm = SoundManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.gameState == GameState.TargetIntro && !isStarted)
        {
                isStarted = true;
                StartCoroutine(Initiate());
        }
    }
    IEnumerator Initiate()
    {
        sm.PlayAudioClip(onToShooting);
        yield return new WaitForSeconds(onToShooting.length + 1);
        TransitionToNextState();
    }
}
