using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Customisation
{
    public class Set : MonoBehaviour
    {
        #region Variables
        [Header("Character Name")]
        public string characterName;
        [Header("Character Class")]
        public CharacterClass characterClass = CharacterClass.Fighter;
        public string[] selectedClass;
        [Header("Dropdown Menu")]
        public Dropdown classDropdown;
        public int statPoints;
        [Header("Texture Lists")]
        public List<Texture2D> skin = new List<Texture2D>();
        public List<Texture2D> eyes, hair, mouth, armour, clothes = new List<Texture2D>();
        [Header("Index")]
        public int skinIndex;
        public int eyesIndex, hairIndex, mouthIndex, armourIndex, clothesIndex;
        [Header("Renderer")]
        public Renderer characterRenderer;
        [Header("Max textures per type")]
        public int skinMax;
        public int eyesMax, hairMax, mouthMax, armourMax, clothesMax;
        #endregion
        void Start()
        {
            selectedClass = new string[] { "Fighter", "Rogue", "Witch" };
            TextureStart();
        }

        void TextureStart()
        {
            for (int i = 0; i < skinMax; i++)
            {
                Texture2D tempTexture = Resources.Load("Character/Skin_" + i) as Texture2D;
                skin.Add(tempTexture);
            }
            for (int i = 0; i < eyesMax; i++)
            {
                Texture2D tempTexture = Resources.Load("Character/Eyes_" + i) as Texture2D;
                eyes.Add(tempTexture);
            }
            for (int i = 0; i < hairMax; i++)
            {
                Texture2D tempTexture = Resources.Load("Character/Hair_" + i) as Texture2D;
                hair.Add(tempTexture);
            }
            for (int i = 0; i < mouthMax; i++)
            {
                Texture2D tempTexture = Resources.Load("Character/Mouth_" + i) as Texture2D;
                mouth.Add(tempTexture);
            }
            for (int i = 0; i < armourMax; i++)
            {
                Texture2D tempTexture = Resources.Load("Character/Armour_" + i) as Texture2D;
                armour.Add(tempTexture);
            }
            for (int i = 0; i < clothesMax; i++)
            {
                Texture2D tempTexture = Resources.Load("Character/Clothes_" + i) as Texture2D;
                clothes.Add(tempTexture);
            }
        }


    }
}
