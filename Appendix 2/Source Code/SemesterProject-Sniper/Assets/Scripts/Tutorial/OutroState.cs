using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroState : MonoBehaviour, iGameState
{
    private bool isStarted;
    private SoundManager sm;
    public AudioClip outro;
    public void TransitionToNextState()
    {
        Debug.Log("Finished the final state");
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
        if (GameStateManager.gameState == GameState.Outro && isStarted == false)
        {
            isStarted = true;
            StartCoroutine(Initiate());
        }
    }
    IEnumerator Initiate()
    {
        sm.PlayAudioClip(outro);
        yield return new WaitForSeconds(outro.length + 3);
        SceneManager.LoadScene("MainMenu");
        
    }
}
