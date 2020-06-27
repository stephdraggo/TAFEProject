using System;
using UnityEngine;
using UnityEngine.UI;

namespace Jim //it's life
{
    public class Life : MonoBehaviour
    {
        [Header("Life")]
        public string characterName;
        public AiBehaviour behaviour;
        public float moveSpeed, aggroRadius, attackRadius;
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
            public int value, tempValue;
        }
        #endregion
        #region AI Behaviours
        public void Wander()
        {
            speedBonus = false;
        }
        public void AvoidCollision()
        {

        }
        public void Flee()
        {
            speedBonus = true;
        }
        public void Evade()
        {
            speedBonus = true;
        }
        #endregion
    }
}
public enum AiBehaviour
{
    Player,
    Wandering,
    Fleeing,
    Hidden,
    Patrolling,
    Chasing
}