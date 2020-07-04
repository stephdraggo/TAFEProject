using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    [AddComponentMenu("Game Systems/Quest/Control")]
    [System.Serializable]
    public class Control : MonoBehaviour
    {
        public QuestState questState;
        public string title, description;
        public int experienceReward, goldReward;
        public Goal goal;

        public void Complete()
        {
            questState = QuestState.Complete;
            Debug.Log(title + " is complete.");
        }
        public void Claim()
        {
            questState = QuestState.Claimed;
        }
    }
}