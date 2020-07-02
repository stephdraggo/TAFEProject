using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace Settings
{
    [AddComponentMenu("Game Systems/Settings/Options")]
    public class Options : MonoBehaviour
    {
        #region Variables
        [Header("Variables")]
        public Dropdown resolutionSelect;
        public Resolution[] resolutions;
        public AudioMixer audioControl;
        public AudioSource audioSource;
        public bool muted;
        private SceneControl scene; //may not work, see Start
        #endregion
        void Start()
        {
            //expose sound parameters
            //figure out how to make the mute toggle better
            //figure out click sounds
            
            if (scene.sceneName == "MainMenu") //this may not work
                //trying to prevent fullscreen from resetting every time I load a scene
            {
                Screen.fullScreen = true;
            }
            SetupRes();
        }

        void Update()
        {

        }
        #region functions
        public void SetupRes() //set up the resolution options according to the screen
        {
            resolutions = Screen.resolutions; //comment this code
            resolutionSelect.ClearOptions();
            List<string> options = new List<string>();
            int index = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    index = i;
                }
            }
            resolutionSelect.AddOptions(options);
            resolutionSelect.value = index;
            resolutionSelect.RefreshShownValue();
        }
        public void SetResolution(int index) //player changes resolution here
        {
            Resolution res = resolutions[index];
            Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        }
        public void SetFullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }
        #region sound
        public void SetMusicVolume(float volume)
        {
            audioControl.SetFloat("music", volume);
        }
        public void SetSFXVolume(float volume)
        {
            audioControl.SetFloat("sfx", volume);
        }
        public void PlayClick()
        {
            audioSource.clip = clicks;
            audioSource.Play();
        }
        public void MuteToggle(bool muted)
        {
            if (muted)
            {
                audioControl.SetFloat("volume", -40);
            }
            else
            {
                audioControl.SetFloat("volume", 0);
            }
        }
        #endregion
        public void SetGraphics(int index)
        {
            QualitySettings.SetQualityLevel(index);
        }
        #endregion
    }
}