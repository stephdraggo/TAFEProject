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

            Vector3 randomDirection = new Vector3(UnityEngine.Random.Range(-1, 1), 0, UnityEngine.Random.Range(-1, 1)); //have to specify library bc ambiguous with System
            transform.position = Vector3.MoveTowards(transform.position, randomDirection, moveSpeed * Time.deltaTime); //move
        }
        public void AvoidCollision(GameObject target)
        {
            transform.position = Vector3.MoveTowards(transform.position, -target.transform.position, moveSpeed * Time.deltaTime); //move away from target
        }
        public void Flee(GameObject target)
        {
            if (behaviour != AiBehaviour.Fleeing) //update state
            {
                behaviour = AiBehaviour.Fleeing;
            }

            speedBonus = true;

            transform.position = Vector3.MoveTowards(transform.position, -target.transform.position, moveSpeed * Time.deltaTime); //move away from target
        }
        #endregion
        #region miscellaneous functions
        public void FindClosestCreature()
        {
            //figure out how to find closest creature
            //closestCreature cannot be hidden

            //culling group?
        }
        public void MoveInTargetDirection(GameObject target) //doubles as flock maybe?
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime); //move towards target
        }
        public void RegenLifeForce(LifeForce i)
        {
            if (i.currentValue < i.maxValue) //if below max
            {
                i.currentValue += i.regenValue * Time.deltaTime; //increase
            }
            if (i.currentValue > i.maxValue) //if above max
            {
                i.currentValue = i.maxValue; //set to max
            }
        }
        public void KillCreature()
        {
            //add loot and murderer here
            Destroy(gameObject); //kill creature
        }
        #endregion
    }
}
