using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionState : MonoBehaviour, iGameState
{
    private bool isStarted;
    private SoundManager sm;
    private GunModelManager gmm;

    public AudioClip brilliant;

    public void TransitionToNextState()
    {
        Debug.Log("Transitioning to ControllerIntroTwo State");
        GameStateManager.gameState = GameState.ControllerIntroTwo;
    }

    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
        sm = SoundManager.Instance;
        gmm = GunModelManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.gameState == GameState.Transition && isStarted == false)
        {
            isStarted = true;
            StartCoroutine(Initiate());
        }
    }
    IEnumerator Initiate()
    {
        yield return new WaitForSeconds(1);
        sm.PlayAudioClip(brilliant);
        yield return new WaitForSeconds(brilliant.length + 1.5f);
        gmm.SwitchModels();

        TransitionToNextState();
    }
}
