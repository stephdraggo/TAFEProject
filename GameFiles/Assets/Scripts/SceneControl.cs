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
        //game scene panels: HUD, Pause, Options, Loading, Inventory, Quests
        //menu scene panels: AnyKey, Main, Options, Loading
        [Header("Loading Screen")]
        public Image loadingPercentBar;
        public Text loadingPercentText;
        #endregion
        void Start()
        {
            sceneName = SceneManager.GetActiveScene().name;
            for (int i = 0; i < panels.Length; i++) //for all panels
            {
                panels[i].SetActive(false); //disable them
            }
            panels[0].SetActive(true); //enable HUD or AnyKey panel
        }

        void Update()
        {
            if(sceneName == "MainMenu")
            {
                if (panels[0].activeSelf)
                {
                    PressAnyKey();
                }
            }
            if (sceneName == "GamePlay")
            {
                PauseKey();
            }
        }
        #region Functions
        #region shared functions
        public void QuitApplication()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
        public void ChangeScene(int sceneIndex)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));

        }
        IEnumerator LoadAsynchronously(int sceneIndex)
        {
            AsyncOperation loading = SceneManager.LoadSceneAsync(sceneIndex); //load this scene
            panels[4].SetActive(true); //enable loading screen

            while (!loading.isDone)
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
            gamePaused = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        public void Resume()
        {
            gamePaused = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        public void PauseKey()
        {
            if (Input.GetKeyDown(Controls.Keybinds.keys["Pause"]))
            {
                ActivateCorrectPanels(1);
            }
            if (Input.GetKeyDown(Controls.Keybinds.keys["Inventory"]))
            {
                ActivateCorrectPanels(4);
            }
            if (Input.GetKeyDown(Controls.Keybinds.keys["Quest"]))
            {
                ActivateCorrectPanels(5);
            }
        }
        void TogglePause()
        {
            gamePaused = !gamePaused;
            if (gamePaused)
            {
                Pause();
                return;
            }
            else
            {
                Resume();
                return;
            }
        }
        void ActivateCorrectPanels(int index) //take index of panel
        {
            if (panels[0].activeSelf) //if HUD panel is active
            {
                for (int i = 0; i < panels.Length; i++) //for all panels
                {
                    panels[i].SetActive(false); //disable them
                }
                panels[index].SetActive(true); //activate panel with given index
                TogglePause();
            }
            else if (panels[index].activeSelf) //if referenced panel is active
            {
                for (int i = 0; i < panels.Length; i++) //for all panels
                {
                    panels[i].SetActive(false); //disable them
                }
                panels[0].SetActive(true); //enable HUD panel
                TogglePause();
            }
        }
        #endregion
        #region menu functions
        void PressAnyKey()
        {
            if (Input.anyKeyDown)
            {
                panels[1].SetActive(true);
                panels[0].SetActive(false);
            }
        }
        #endregion
        #endregion
    }
}