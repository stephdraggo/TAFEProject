using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Customisation
{
    public class Get : MonoBehaviour
    {
        #region Variables
        public Jim.Player player;
        public Renderer characterMesh;
        #endregion
        void Start()
        {
            Load();
        }

        void Update()
        {

        }
        #region Functions
        void SetTexture(string type, int index)
        {
            Texture2D texture = null;
            int matIndex = 0;
            switch (type)
            {
                case "Skin":
                    texture = Resources.Load("Character/Skin_" + index) as Texture2D;
                    matIndex = 1;
                    break;
                case "Eyes":
                    texture = Resources.Load("Character/Eyes_" + index) as Texture2D;
                    matIndex = 2;
                    break;
                case "Mouth":
                    texture = Resources.Load("Character/Mouth_" + index) as Texture2D;
                    matIndex = 3;
                    break;
                case "Hair":
                    texture = Resources.Load("Character/Hair_" + index) as Texture2D;
                    matIndex = 4;
                    break;
                case "Clothes":
                    texture = Resources.Load("Character/Clothes_" + index) as Texture2D;
                    matIndex = 5;
                    break;
                case "Armour":
                    texture = Resources.Load("Character/Armour_" + index) as Texture2D;
                    matIndex = 5;
                    break;
            }
            Material[] mats = characterMesh.materials;
            mats[matIndex].mainTexture = texture;
            characterMesh.materials = mats;
        }
        void Load()
        {
            if (!PlayerPrefs.HasKey("CharacterName"))
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                player.gameObject.name = PlayerPrefs.GetString("CharacterName");

                SetTexture("Skin", PlayerPrefs.GetInt("SkinIndex"));
                SetTexture("Eyes", PlayerPrefs.GetInt("EyesIndex"));
                SetTexture("Mouth", PlayerPrefs.GetInt("MouthIndex"));
                SetTexture("Hair", PlayerPrefs.GetInt("HairIndex"));
                SetTexture("Clothes", PlayerPrefs.GetInt("ClothesIndex"));
                SetTexture("Armour", PlayerPrefs.GetInt("ArmourIndex"));

                for (int i = 0; i < player.stats.Length; i++)
                {
                    player.stats[i].value = PlayerPrefs.GetInt(player.stats[i].name);
                }
            }
        }
        #endregion
    }
}