using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Controls
{
    [AddComponentMenu("Game Systems/Controls/Keybinds")]
    public class Keybinds : MonoBehaviour
    {
        #region Variables
        [Header("Variables")]
        [SerializeField]
        public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

        public GameObject currentKey;
        public Color32 selectKey, changeKey;

        [Serializable]
        public struct KeyButtons
        {
            public string keyName;
            public Text keyDisplayText;
            public string defaultKey;
        }
        public KeyButtons[] baseKeys;
        #endregion
        void Start()
        {
            if (keys.Count < 1)
            {
                DefaultKeys();
                for (int i = 0; i < baseKeys.Length; i++)
                {
                    baseKeys[i].keyDisplayText.text = keys[baseKeys[i].keyName].ToString();
                }
            }
        }

        void Update()
        {

        }

        void OnGUI()
        {
            string newKey = "";
            Event e = Event.current;
            if (currentKey != null)
            {
                if (e.isKey)
                {
                    newKey = e.keyCode.ToString();
                }
                #region Shift Key Fix
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    newKey = "Left Shift";
                }
                if (Input.GetKey(KeyCode.RightShift))
                {
                    newKey = "Right Shift";
                }
                #endregion
                if (newKey != "")
                {
                    keys[currentKey.name] = (KeyCode)Enum.Parse(typeof(KeyCode), newKey); //changes key in dictionary
                    currentKey.GetComponentInChildren<Text>().text = newKey; //changes key text
                    currentKey.GetComponent<Image>().color = changeKey;
                    currentKey = null;
                }
            }
        }
        #region keybindFunctions
        public void DefaultKeys()
        {
            for (int i = 0; i < baseKeys.Length; i++)
            {
                keys.Add(baseKeys[i].keyName, (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(baseKeys[i].keyName, baseKeys[i].defaultKey)));
            }
        }
        public void SaveKeys()
        {
            foreach (var key in keys)
            {
                PlayerPrefs.SetString(key.Key, key.Value.ToString());
            }
            PlayerPrefs.Save();
        }
        public void ChangeKey(GameObject clickedKey)
        {
            currentKey = clickedKey;
            if (clickedKey != null)
            {
                currentKey.GetComponent<Image>().color = selectKey;
            }
        }
        #endregion
    }
}