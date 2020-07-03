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
        [Header("Dropdown Menu")]
        public Dropdown classDropdown; //needed?
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
    }
}
public enum CharacterClass
{
    Fighter,
    Rogue,
    Witch
}
