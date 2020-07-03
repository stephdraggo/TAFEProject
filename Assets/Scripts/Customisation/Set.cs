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
        [Header("Character Class")]
        public CharacterClass characterClass = CharacterClass.Fighter;
        public string[] selectedClass;
        public int selectedClassIndex = 0; //what do??
        public Jim.Player player;
        [Header("Dropdown Menu")]
        public Dropdown classDropdown;
        public int statPoints;
        [Header("Texture Lists")]
        public List<Texture2D> skin = new List<Texture2D>();
        public List<Texture2D> eyes, hair, mouth, clothes, armour = new List<Texture2D>();
        [Header("Index")]
        public int skinIndex;
        public int eyesIndex, hairIndex, mouthIndex, clothesIndex, armourIndex;
        [Header("Renderer")]
        public Renderer characterRenderer;
        [Header("Max textures per type")]
        public int skinMax;
        public int eyesMax, hairMax, mouthMax, clothesMax, armourMax;
        #endregion
        void Start()
        {
            selectedClass = new string[] { "Fighter", "Rogue", "Witch" };
            TextureStart();
        }
        #region Functions
        #region Texture Functions
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
            for (int i = 0; i < clothesMax; i++)
            {
                Texture2D tempTexture = Resources.Load("Character/Clothes_" + i) as Texture2D;
                clothes.Add(tempTexture);
            }
            for (int i = 0; i < armourMax; i++)
            {
                Texture2D tempTexture = Resources.Load("Character/Armour_" + i) as Texture2D;
                armour.Add(tempTexture);
            }
        }
        void SetTexture(string type, int dir)
        {
            int index = 0, max = 0, matIndex = 0;
            Texture2D[] textures = new Texture2D[0]; //why all 0??
            switch (type)
            {
                case "Skin":
                    index = skinIndex;
                    max = skinMax;
                    textures = skin.ToArray();
                    matIndex = 0;
                    break;
                case "Eyes":
                    index = eyesIndex;
                    max = eyesMax;
                    textures = eyes.ToArray();
                    matIndex = 1;
                    break;
                case "Hair":
                    index = hairIndex;
                    max = hairMax;
                    textures = hair.ToArray();
                    matIndex = 2;
                    break;
                case "Mouth":
                    index = mouthIndex;
                    max = mouthMax;
                    textures = mouth.ToArray();
                    matIndex = 3;
                    break;
                case "Clothes":
                    index = clothesIndex;
                    max = clothesMax;
                    textures = clothes.ToArray();
                    matIndex = 4;
                    break;
                case "Armour":
                    index = armourIndex;
                    max = armourMax;
                    textures = armour.ToArray();
                    matIndex = 5;
                    break;
            }
            index += dir;
            if (index < 0)
            {
                index = max - 1;
            }
            if (index > max - 1)
            {
                index = 0;
            }
            Material[] mat = characterRenderer.materials;
            mat[matIndex].mainTexture = textures[index];
            characterRenderer.materials = mat;

            switch (type)
            {
                case "Skin":
                    skinIndex = index;
                    break;
                case "Eyes":
                    eyesIndex = index;
                    break;
                case "Hair":
                    hairIndex = index;
                    break;
                case "Mouth":
                    mouthIndex = index;
                    break;
                case "Clothes":
                    clothesIndex = index;
                    break;
                case "Armour":
                    armourIndex = index;
                    break;
            }
        }
        public void TextureLeft(string type)
        {
            SetTexture(type, -1);
        }
        public void TextureRight(string type)
        {
            SetTexture(type, 1);
        }
        #endregion
        public void ChooseClass(int classIndex)
        {
            switch (classIndex)
            {
                case 0:
                    player.stats[0].baseValue = 5; //str, end, agi, cha, aur, tho
                    player.stats[1].baseValue = 4;
                    player.stats[2].baseValue = 3;
                    player.stats[3].baseValue = 3;
                    player.stats[4].baseValue = 1;
                    player.stats[5].baseValue = 2;
                    characterClass = CharacterClass.Fighter;
                    break;
                case 1:
                    player.stats[0].baseValue = 2; //str, end, agi, cha, aur, tho
                    player.stats[1].baseValue = 1;
                    player.stats[2].baseValue = 5;
                    player.stats[3].baseValue = 4;
                    player.stats[4].baseValue = 3;
                    player.stats[5].baseValue = 3;
                    characterClass = CharacterClass.Rogue;
                    break;
                case 2:
                    player.stats[0].baseValue = 1; //str, end, agi, cha, aur, tho
                    player.stats[1].baseValue = 3;
                    player.stats[2].baseValue = 3;
                    player.stats[3].baseValue = 2;
                    player.stats[4].baseValue = 5;
                    player.stats[5].baseValue = 4;
                    characterClass = CharacterClass.Witch;
                    break;
            }
        }
        public void SaveCharacter()
        {
            PlayerPrefs.SetInt("SkinIndex", skinIndex);
            PlayerPrefs.SetInt("EyesIndex", eyesIndex);
            PlayerPrefs.SetInt("HairIndex", hairIndex);
            PlayerPrefs.SetInt("MouthIndex", mouthIndex);
            PlayerPrefs.SetInt("ClothesIndex", clothesIndex);
            PlayerPrefs.SetInt("ArmourIndex", armourIndex);

            PlayerPrefs.SetString("CharacterName", player.characterName);

            for (int i = 0; i < player.stats.Length; i++)
            {
                player.stats[i].value = player.stats[i].baseValue + player.stats[i].tempValue;
                PlayerPrefs.SetInt(player.stats[i].name, player.stats[i].value);
            }
        }


        #endregion
    }
}
