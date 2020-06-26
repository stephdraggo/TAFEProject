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
        void Wander()
        {
            behaviour = AiBehaviour.Wandering; //this is all wrong
        }
        void AvoidCollision()
        {

        }
        void Flee()
        {
            behaviour = AiBehaviour.Fleeing;
        }
        void Evade()
        {

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