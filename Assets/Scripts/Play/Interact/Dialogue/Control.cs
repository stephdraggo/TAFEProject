using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//will break if only one dialogueText
namespace Dialogue
{
    [AddComponentMenu("Game Systems/Dialogue/Control")]
    public class Control : MonoBehaviour
    {
        #region Variables
        public Text currentDialogue, npcNameText;
        public bool showDialogue; //do we need this??
        public int index;
        public string[] dialogueText;
        public string npcName;
        public GameObject nextButton, byeButton;


        #endregion
        void Start()
        {

        }

        public void OnEnable() //like Start but runs every time it is activated instead of once total
        {
            index = 0; //reset dialogue progress
            npcNameText.text = npcName; //NPC name tag
            if (dialogueText.Length <= 1) //if only one dialogue text
            {
                nextButton.SetActive(false); //disable next
                byeButton.SetActive(true); //enable bye
            }
            else
            {
                nextButton.SetActive(true); //enable next
                byeButton.SetActive(false); //disable bye
            }

        }

        void Update()
        {
            currentDialogue.text = dialogueText[index]; //update dialogue text according to index
        }

        public void Next()
        {
            if (index == dialogueText.Length - 1) //if on last text
            {
                nextButton.SetActive(false); //disable next
                byeButton.SetActive(true); //enable bye
            }
            else
            {
                index++; //next text
            }
        }
    }
}