using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerIntroOneState : MonoBehaviour, iGameState
{
    private bool isStarted;
    private SoundManager sm;
    private bool waitingForPlayerInput;
    public GameObject arrow;

    public AudioClip great;

    public void TransitionToNextState()
    {
        Debug.Log("Transitioning to Transition State");
        GameStateManager.gameState = GameState.Transition;
    }

    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
        waitingForPlayerInput = false;
        sm = SoundManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.gameState == GameState.ControllerIntroOne && isStarted == false)
        {
            isStarted = true;
            StartCoroutine(Initiate());
        }
        if (GameStateManager.gameState == GameState.ControllerIntroOne && waitingForPlayerInput)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                StopCoroutine(MovingArrow());
                arrow.SetActive(false);
                waitingForPlayerInput = false;
                Debug.Log("Trigger pressed. Can progress to next state.");
                TransitionToNextState();
            }
        }
    }
    IEnumerator Initiate()
    {
        yield return new WaitForSeconds(1);
        sm.PlayAudioClip(great);
        yield return new WaitForSeconds(great.length + 1);
        waitingForPlayerInput = true;
        StartCoroutine(MovingArrow());
    }
    private IEnumerator MovingArrow()
    {
        Debug.Log("Moving Arrow in ControllerIntroOne called");
        while (waitingForPlayerInput)
        {
            arrow.SetActive(true);
            yield return new WaitForSeconds(1);
            arrow.SetActive(false);
            yield return new WaitForSeconds(1);
        }

    }
}
