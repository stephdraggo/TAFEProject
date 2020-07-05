using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogue
{
    [AddComponentMenu("Game Systems/Dialogue/Control")]
    public class Control : MonoBehaviour
    {
        #region Variables
        public Text currentDialogue, buttonText, npcNameText;
        public bool showDialogue;
        public int index;
        public string[] dialogueText;
        public string npcName;
        public Button proceedButton;


        #endregion
        void Start()
        {

        }

        public void OnEnable() //like Start but runs every time it is activated instead of once total
        {
            index = 0; //reset dialogue progress
            npcNameText.text = npcName; //NPC name tag
            buttonText.text = "Next"; //default proceed text
        }

        void Update()
        {
            currentDialogue.text = dialogueText[index]; //update dialogue text according to index
        }

        public void Next() //attach to proceed button, also redo entirely
        {
            if (!(index < dialogueText.Length - 1)) //if we haven't reached the last dialogue
            {
                index++; //move to next index
                if (index < dialogueText.Length - 1) //this is a mess, redo
                {
                    buttonText.text = "Bye";
                }
            }
            else
            {
                buttonText.text = "Next";
            }
        }
    }
}