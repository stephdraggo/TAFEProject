using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Quest
{
    [AddComponentMenu("Game Systems/Quest/Giver")]
    public class Giver : MonoBehaviour
    {

        public Control quest;
        public Jim.Player player;
        public Item.Inventory inventory;
        public GameObject questWindow;

        #region UI
        public Text titleText, descriptionText, experienceText, goldText;
        #endregion

        public void OpenQuestWindow()
        {
            questWindow.SetActive(true);
            titleText.text = quest.title;
            descriptionText.text = quest.description;
            experienceText.text = quest.experienceReward.ToString();
            goldText.text = quest.goldReward.ToString();
        }
        public void AcceptQuest()
        {
            quest.questState = QuestState.Active;
            questWindow.SetActive(false);
            player.quest = quest;
        }
    }
}