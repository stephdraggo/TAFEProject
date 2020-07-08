using System;
using UnityEngine;
using UnityEngine.UI;

namespace Jim //it's life
{
    [AddComponentMenu("Game Systems/Life/Life")]
    public class Life : MonoBehaviour
    {
        [Header("Life")]
        public string characterName;
        public GameObject closestCreature;
        public int level;
        public AiBehaviour behaviour;
        public float moveSpeed, aggroRadius, attackRadius, normalSpeed, fastSpeed;
        public bool speedBonus;
        #region stat structs
        [Serializable]
        public struct LifeForce //health, mana, stamina
        {
            public string name;
            public float maxValue, currentValue, regenValue;
            public Image displayImage;
        }
        [Serializable]
        public struct Stats //strength etc.
        {
            public string name;
            public int value, baseValue, tempValue;
        }
        #endregion
        #region AI Behaviours
        public void Wander()
        {
            if (behaviour != AiBehaviour.Wandering) //update state
            {
                behaviour = AiBehaviour.Wandering;
            }
            speedBonus = false;
        }
        public void AvoidCollision()
        {

        }
        public void Flee(GameObject target)
        {
            if (behaviour != AiBehaviour.Fleeing) //update state
            {
                behaviour = AiBehaviour.Fleeing;
            }
            speedBonus = true;
        }
        public void Evade(GameObject target)
        {
            speedBonus = true;
        }
        public void TakeDamage(GameObject attacker)
        {

        }
        #endregion
        #region miscelaneous functions
        public void FindClosestCreature()
        {
            //figure out how to find closest creature
            //closestCreature cannot be hidden
        }

        public void RegenLifeForce(LifeForce lifeForce)
        {
            if (lifeForce.currentValue < lifeForce.maxValue) //if below max
            {
                lifeForce.currentValue += lifeForce.regenValue * Time.deltaTime; //increase, will this time thing work?
            }
            if (lifeForce.currentValue > lifeForce.maxValue) //if above max
            {
                lifeForce.currentValue = lifeForce.maxValue; //set to max
            }
        }
        #endregion
    }
}
