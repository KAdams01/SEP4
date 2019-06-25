using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace CurvedUI
{


    public class UIHighlightPauseMenu : MonoBehaviour
    {

        public Button resumeButtonOnHoverEnter;
        public Button resumeButtonOnHoverExit;
        public Button returnToMainMenuButtonOnHoverEnter;
        public Button returnToMainMenuButtonOnHoverExit;
        public Button exitGameButtonOnHoverEnter;
        public Button exitGameButtonOnHoverExit;

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
                        case "BoxColliderResumeButton":
                            {
                                soundManager.PlayAudioClip(hoverOverButton);
                                resumeButtonOnHoverEnter.gameObject.SetActive(true);
                                resumeButtonOnHoverExit.gameObject.SetActive(false);
                                stateChanged = true;
                                break;
                            }
                        case "BoxColliderReturntoMainMenuButton":
                            {
                                soundManager.PlayAudioClip(hoverOverButton);
                                returnToMainMenuButtonOnHoverEnter.gameObject.SetActive(true);
                                returnToMainMenuButtonOnHoverExit.gameObject.SetActive(false);
                                stateChanged = true;
                                break;
                            }
                        case "BoxColliderExitGameButton":
                            {
                                soundManager.PlayAudioClip(hoverOverButton);
                                exitGameButtonOnHoverEnter.gameObject.SetActive(true);
                                exitGameButtonOnHoverExit.gameObject.SetActive(false);
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
                    resumeButtonOnHoverExit.gameObject.SetActive(true);
                    resumeButtonOnHoverEnter.gameObject.SetActive(false);
                    returnToMainMenuButtonOnHoverExit.gameObject.SetActive(true);
                    returnToMainMenuButtonOnHoverEnter.gameObject.SetActive(false);
                    exitGameButtonOnHoverExit.gameObject.SetActive(true);
                    exitGameButtonOnHoverEnter.gameObject.SetActive(false);
                    stateChanged = false;
                }
            }
        }
    }
}

