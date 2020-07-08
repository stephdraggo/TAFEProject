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
        public AudioClip clicks;
        public bool muted, savedOptions; //fullscreen?
        public SceneControl sceneControl; //may not be needed, see Start
        #endregion
        void Start()
        {
            //expose sound parameters
            //figure out how to make the mute toggle better
            //figure out click sounds


            if (savedOptions) //if there are saved options
            {
                //load from player prefs
            }
            else //if no saved options
            {
                //default settings go here
                Screen.fullScreen = true; //fullscreen bool?
            }
            SetupRes(); //still don't know if this will reset every scene, test
        }

        void Update()
        {

        }
        #region functions
        public void SetupRes() //set up the resolution options according to the screen
        {
            resolutions = Screen.resolutions; //fill the array with possibilities from this screen
            resolutionSelect.ClearOptions(); //clear selection from dropdown
            List<string> options = new List<string>(); //will hold dimensions text list
            int index = 0;
            for (int i = 0; i < resolutions.Length; i++) //for every resolution option
            {
                string option = resolutions[i].width + " x " + resolutions[i].height; //set dimensions text
                options.Add(option); //add text to list
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) //if option is current dimensions
                {
                    index = i; //set current index
                }
            }
            resolutionSelect.AddOptions(options); //put all the options in the dropdown
            resolutionSelect.value = index; //set the selected option to current dimensions index
            resolutionSelect.RefreshShownValue(); //reload dropdown
        }
        public void SetResolution(int i) //player changes resolution here
        {
            Screen.SetResolution(resolutions[i].width, resolutions[i].height, Screen.fullScreen); //why fullscreen?
        }
        public void SetFullScreen(bool full)
        {
            Screen.fullScreen = full;
            //set bool?
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
        public void SaveOptions()
        {
            //save to player prefs
        }
        #endregion
    }
}