using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Settings
{
    [AddComponentMenu("Game Systems/Settings/Scene Control")]
    public class SceneControl : MonoBehaviour
    {
        #region Variables
        [Header("Variables")]
        public string sceneName;
        public bool gamePaused;
        public GameObject[] panels;
        //game scene panels: HUD, Pause, Options, Loading, Inventory, Quests, Death, Dialogue
        //menu scene panels: AnyKey, Main, Options, Loading
        [Header("Loading Screen")]
        public Image loadingPercentBar;
        public Text loadingPercentText;
        #endregion
        void Start()
        {
            sceneName = SceneManager.GetActiveScene().name; //get name of current scene
            ActivateCorrectPanels(0); //only HUD or AnyKey
        }

        void Update()
        {
            #region Menu Scene
            if (sceneName == "MainMenu") //if in menu scene
            {
                if (panels[0].activeSelf) //if AnyKey panel active
                {
                    PressAnyKey(); //notice inputs
                }
            }
            #endregion

            #region Game Scene
            if (sceneName == "GamePlay") //if in game scene
            {
                if (Jim.Player.isDead && !gamePaused) //if dead and calls only once
                {
                    Pause();
                    ActivateCorrectPanels(6); //death panel
                }
                else if (Jim.Player.isDead) //if dead update
                {

                }
                else //if alive
                {
                    PauseKey(); //notice pause keys
                }

            }
            #endregion
        }
        #region Functions
        #region shared functions
        public void QuitApplication()
        {
#if UNITY_EDITOR //if in unity
            UnityEditor.EditorApplication.isPlaying = false; //exit play mode
#endif
            Application.Quit(); //close app
        }
        public void ChangeScene(int sceneIndex)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }
        IEnumerator LoadAsynchronously(int sceneIndex)
        {
            AsyncOperation loading = SceneManager.LoadSceneAsync(sceneIndex); //load this scene
            panels[4].SetActive(true); //enable loading screen

            while (!loading.isDone) //while not done loading
            {
                float progress = Mathf.Clamp01(loading.progress / 0.9f); //loading progress

                loadingPercentBar.fillAmount = progress; //fill percent bar
                loadingPercentText.text = progress * 100 + "%"; //percent text
                yield return null;
            }
        }
        #endregion
        #region in-game functions
        public void Pause()
        {
            gamePaused = true; //static bool set true
            Time.timeScale = 0; //pause time
            Cursor.lockState = CursorLockMode.None; //release mouse
            Cursor.visible = true; //make mouse visible
        }
        public void Resume()
        {
            gamePaused = false; //static bool set false
            Time.timeScale = 1; //time is passing at a normal rate
            Cursor.lockState = CursorLockMode.Locked; //imobilise mouse
            Cursor.visible = false; //make mouse invisible
        }
        public void PauseKey()
        {
            if (Input.GetKeyDown(Controls.Keybinds.keys["Pause"])) //if key 'pause'
            {
                ActivateCorrectPanels(1); //toggle pause panel
                TogglePause();
            }
            if (Input.GetKeyDown(Controls.Keybinds.keys["Inventory"])) //if key 'inventory'
            {
                ActivateCorrectPanels(4); //toggle inventory panel
                TogglePause();
            }
            if (Input.GetKeyDown(Controls.Keybinds.keys["Quest"])) //if key 'quest'
            {
                ActivateCorrectPanels(5); //toggle quest panel
                TogglePause();
            }
        }
        void TogglePause()
        {
            if (!gamePaused) //if bool false
            {
                Pause();
                return;
            }
            else //if bool true
            {
                Resume();
                return;
            }
        }
        void ActivateCorrectPanels(int index) //take index of panel
        {
            if (panels[0].activeSelf) //if HUD/AnyKey panel is active
            {
                for (int i = 0; i < panels.Length; i++) //for all panels
                {
                    panels[i].SetActive(false); //disable them
                }
                panels[index].SetActive(true); //activate panel with given index
                return;
            }
            if (panels[index].activeSelf || index == 0) //if referenced panel is active or referenced panel is HUD/AnyKey panel
            {
                for (int i = 0; i < panels.Length; i++) //for all panels
                {
                    panels[i].SetActive(false); //disable them
                }
                panels[0].SetActive(true); //enable HUD/AnyKey panel
                return;
            }
        }
        #endregion
        #region menu functions
        void PressAnyKey()
        {
            if (Input.anyKeyDown)
            {
                ActivateCorrectPanels(1);
            }
        }
        #endregion
        #endregion
    }
}