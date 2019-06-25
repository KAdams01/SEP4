using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace CurvedUI
{

    public class UIHighlight : MonoBehaviour
    {
        public Button playButtonOnHoverEnter;
        public Button playButtonOnHoverExit;
        public Button settingsButtonOnHoverEnter;
        public Button settingsButtonOnHoverExit;
        public Button exitButtonOnHoverEnter;
        public Button exitButtonOnHoverExit;
        public Button tutorialButtonOnHoverEnter;
        public Button tutorialButtonOnHoverExit;
        public Button practiceModeButtonOnHoverEnter;
        public Button practiceModeButtonOnHoverExit;
        public Button targetRangeButtonOnHoverEnter;
        public Button targetRangeButtonOnHoverExit;

        public CUI_ViveLaserBeam raycastScript;

        public AudioClip hoverOverButton;

        private bool stateChanged;
        private SoundManager soundManager;

        // Start is called before the first frame update
        void Start()
        {
            stateChanged = false;
            soundManager = SoundManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            if (raycastScript.hit.transform != null)
            {
                if (raycastScript.hit.transform.gameObject.tag.Equals("Button") && !stateChanged)
                {
                    switch (raycastScript.hit.transform.gameObject.name)
                    {
                        case "BoxColliderPlayButton":
                            {
                                soundManager.PlayAudioClip(hoverOverButton);
                                playButtonOnHoverEnter.gameObject.SetActive(true);
                                playButtonOnHoverExit.gameObject.SetActive(false);
                                stateChanged = true;
                                break;
                            }
                        case "BoxColliderSettingsButton":
                            {
                                soundManager.PlayAudioClip(hoverOverButton);
                                settingsButtonOnHoverEnter.gameObject.SetActive(true);
                                settingsButtonOnHoverExit.gameObject.SetActive(false);
                                stateChanged = true;
                                break;
                            }
                        case "BoxColliderExitButton":
                            {
                                soundManager.PlayAudioClip(hoverOverButton);
                                exitButtonOnHoverEnter.gameObject.SetActive(true);
                                exitButtonOnHoverExit.gameObject.SetActive(false);
                                stateChanged = true;
                                break;
                            }
                        case "BoxColliderTutorialButton":
                            {
                                soundManager.PlayAudioClip(hoverOverButton);
                                tutorialButtonOnHoverEnter.gameObject.SetActive(true);
                                tutorialButtonOnHoverExit.gameObject.SetActive(false);
                                stateChanged = true;
                                break;
                            }
                        case "BoxColliderPracticeModeButton":
                            {
                                soundManager.PlayAudioClip(hoverOverButton);
                                practiceModeButtonOnHoverEnter.gameObject.SetActive(true);
                                practiceModeButtonOnHoverExit.gameObject.SetActive(false);
                                stateChanged = true;
                                break;
                            }
                        case "BoxColliderTargetRangeButton":
                            {
                                soundManager.PlayAudioClip(hoverOverButton);
                                targetRangeButtonOnHoverEnter.gameObject.SetActive(true);
                                targetRangeButtonOnHoverExit.gameObject.SetActive(false);
                                stateChanged = true;
                                break;
                            }

                    }
                }

                else if (raycastScript.hit.transform.gameObject.tag.Equals("Button") && stateChanged)
                {
                    //Do nothing
                }
                else
                {
                    playButtonOnHoverExit.gameObject.SetActive(true);
                    playButtonOnHoverEnter.gameObject.SetActive(false);
                    settingsButtonOnHoverExit.gameObject.SetActive(true);
                    settingsButtonOnHoverEnter.gameObject.SetActive(false);
                    exitButtonOnHoverExit.gameObject.SetActive(true);
                    exitButtonOnHoverEnter.gameObject.SetActive(false);
                    tutorialButtonOnHoverExit.gameObject.SetActive(true);
                    tutorialButtonOnHoverEnter.gameObject.SetActive(false);
                    practiceModeButtonOnHoverExit.gameObject.SetActive(true);
                    practiceModeButtonOnHoverEnter.gameObject.SetActive(false);
                    targetRangeButtonOnHoverExit.gameObject.SetActive(true);
                    targetRangeButtonOnHoverEnter.gameObject.SetActive(false);
                    stateChanged = false;
                }
            }
        }
    }
}

