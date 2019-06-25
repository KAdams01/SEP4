using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CurvedUI
{
    public class InputManager : MonoBehaviour
    {
        //public static InputManager instance = null;
        public FireWeapon fireWeapon;
        public ScopeZoomLevel scopeZoomLevel;
        public GameObject pauseMenu;
        public CUI_ViveLaserBeam raycastScript;
        public Camera centerEyeAnchorCamera;
        public LayerMask uILayerMask;
        public LayerMask everythingLayerMask;
        public AudioClip buttonClick;
        private GunModelManager gmm;

        private SoundManager sm;

        private bool inPauseMenu;

        /*void Awake()
        {
            //Check if instance already exists
            if (instance == null)
            {
                //if not, set instance to this
                instance = this;
            }
            //If instance already exists and it's not this:
            else if (instance != this)
            {
                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);
            }
            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
        }*/

        // Use this for initialization
        void Start()
        {
            //FireWeaponGameObject = GetComponent<FireWeapon>();
            sm = SoundManager.Instance;
            gmm = GunModelManager.Instance;
            inPauseMenu = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (GunModelManager.currentWeapon == GunModelManager.currentlySelected.Sniper && GameStateManager.gameState != GameState.Transition)
            {
                if (Input.mouseScrollDelta.y > 0 || Input.GetKeyDown(KeyCode.UpArrow) || OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickUp) || OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickUp))
                {
                    scopeZoomLevel.ZoomIn();
                    //gunModMan.ShowPrintedModel();
                }
                else if (Input.mouseScrollDelta.y < 0 || Input.GetKeyDown(KeyCode.DownArrow) || OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown) || OVRInput.GetDown(OVRInput.Button.SecondaryThumbstickDown))
                {
                    scopeZoomLevel.ZoomOut();
                    //gunModMan.ShowSniperRifle();
                }
                if (GameStateManager.gameState != GameState.ControllerIntroTwo)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !inPauseMenu)
                    {
                        if (!FireWeapon.reloading)
                        {
                            fireWeapon.ShootWeapon();
                            sm.PlayAudioClipByName("RifleShot");
                        }
                    }


                    if (Input.GetKeyDown(KeyCode.P))
                    {
                        fireWeapon.debugMode = !fireWeapon.debugMode;
                        if (fireWeapon.debugMode)
                        {
                            Time.timeScale = 0.1f;
                            Debug.Log("Debug mode activated");
                        }
                        else
                        {
                            Time.timeScale = 1f;
                            Debug.Log("Debug mode deactivated");
                        }
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gmm.SwitchModels();
            }

            if (OVRInput.GetDown(OVRInput.Button.Four)/* && OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick)*/)
            {
                centerEyeAnchorCamera.cullingMask = uILayerMask;
                Time.timeScale = 0;
                inPauseMenu = true;
                pauseMenu.SetActive(true);
                gmm.ShowPrintedModel();
            }

            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && inPauseMenu)
            {
                switch (raycastScript.hit.transform.gameObject.name)
                {
                    case "BoxColliderResumeButton":
                        {
                            sm.PlayAudioClip(buttonClick);
                            pauseMenu.SetActive(false);
                            gmm.ShowSniperRifle();
                            centerEyeAnchorCamera.cullingMask = everythingLayerMask;
                            Time.timeScale = 1;
                            inPauseMenu = false;
                            break;
                        }
                    case "BoxColliderReturntoMainMenuButton":
                        {
                            sm.PlayAudioClip(buttonClick);
                            Time.timeScale = 1;
                            SceneManager.LoadScene("MainMenu");
                            break;
                        }
                    case "BoxColliderExitGameButton":
                        {
                            sm.PlayAudioClip(buttonClick);
                            UnityEditor.EditorApplication.isPlaying = false;
                            Application.Quit();
                            break;
                        }
                }
            }

        }

    }
}
