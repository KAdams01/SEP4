using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CurvedUI
{

    public class InputManager_MainMenu : MonoBehaviour
    {
        public CUI_ViveLaserBeam raycastScript;
        public GameObject missionsPanel;
        public Animator animator;
        public AudioClip buttonClick;
        public AudioClip reload;

        private SoundManager soundManager;

        private void Start()
        {
            soundManager = SoundManager.Instance;            
        }

        void Update()
        {
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && raycastScript.hit.transform != null)
            {
                switch (raycastScript.hit.transform.gameObject.name)
                {
                    case "BoxColliderPlayButton":
                        {
                            soundManager.PlayAudioClip(buttonClick);
                            missionsPanel.SetActive(true);
                            animator.SetBool("pressed", true);
                            break;
                        }
                    case "BoxColliderSettingsButton":
                        {
                            soundManager.PlayAudioClip(buttonClick);
                            //Time.timeScale = 0;
                            break;
                        }
                    case "BoxColliderExitButton":
                        {
                            soundManager.PlayAudioClip(buttonClick);
                            UnityEditor.EditorApplication.isPlaying = false;
                            Application.Quit();
                            break;
                        }
                    case "BoxColliderTutorialButton":
                        {
                            soundManager.PlayAudioClip(reload);
                            StartCoroutine(WaitABit("Tutorial"));
                            break;
                        }
                    case "BoxColliderPracticeModeButton":
                        {
                            soundManager.PlayAudioClip(reload);
                            StartCoroutine(WaitABit("PracticeMode"));
                            break;
                        }
                    case "BoxColliderTargetRangeButton":
                        {
                            soundManager.PlayAudioClip(reload);
                            StartCoroutine(WaitABit("TargetRange"));
                            break;
                        }
                }
            }
        }

        IEnumerator WaitABit(string sceneName)
        {
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(sceneName);
        }
    }
}
