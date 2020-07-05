using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    [AddComponentMenu("Game Systems/Quest/Goal")]
    [System.Serializable]
    public class Goal
    {
        public GoalType goalType;
        public int requiredAmount, currentAmount, itemId;
        public string enemyType;
        public Vector3 location;

        public bool IsReached()
        {
            return (currentAmount >= requiredAmount);
        }
        public void EnemyKilled(string type)
        {
            if (goalType == GoalType.Kill && type == enemyType)
            {
                currentAmount++;
            }
        }
        public void ItmeGathered(int id)
        {
            if (goalType == GoalType.Kill && id == itemId)
            {
                currentAmount++;
            }
        }
        public void LocationReached()
        {
            if (true)//distance between player and location < 5 or so
            {

            }
        }
    }
}