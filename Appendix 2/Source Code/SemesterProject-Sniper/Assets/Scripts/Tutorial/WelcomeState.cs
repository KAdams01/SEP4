using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeState : MonoBehaviour, iGameState
{
    [SerializeField]
    private AudioClip welcomeClip;
    [SerializeField]
    private AudioClip basicsOfHandling;
    [SerializeField]
    private AudioClip formedGunAlready;
    [SerializeField]
    private AudioClip notLoadedControllers;
    private SoundManager sm;
    private bool isStarted;

    private bool waitingForPlayerInput;

    public GameObject arrow;
    public void TransitionToNextState()
    {
        Debug.Log("Transitioning to ControllerIntroOne");
        GameStateManager.gameState = GameState.ControllerIntroOne;
    }

    // Start is called before the first frame update
    void Start()
    {
        sm = SoundManager.Instance;
        isStarted = false;
        arrow.SetActive(false);
        waitingForPlayerInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.gameState == GameState.Welcome && isStarted == false)
        {
            isStarted = true;
            StartCoroutine(Initiate());
        }
        if(GameStateManager.gameState == GameState.Welcome && waitingForPlayerInput)
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
        yield return new WaitForSeconds(3);
        sm.PlayAudioClip(welcomeClip);
        yield return new WaitForSeconds(welcomeClip.length + 1);
        sm.PlayAudioClip(basicsOfHandling);
        yield return new WaitForSeconds(basicsOfHandling.length + 1);
        sm.PlayAudioClip(formedGunAlready);
        yield return new WaitForSeconds(formedGunAlready.length + 1);
        sm.PlayAudioClip(notLoadedControllers);
        yield return new WaitForSeconds(notLoadedControllers.length + 1);
        waitingForPlayerInput = true;
        StartCoroutine(MovingArrow());
    }

    private IEnumerator MovingArrow()
    {
        Debug.Log("Moving Arrow in Welcome called");
        while (waitingForPlayerInput)
        {
            arrow.SetActive(true);
            yield return new WaitForSeconds(1);
            arrow.SetActive(false);
            yield return new WaitForSeconds(1);
        }

    }
}
