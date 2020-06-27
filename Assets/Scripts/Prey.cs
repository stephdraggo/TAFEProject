using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jim //it's life
{
    public class Prey : Life
    {
        #region Variables
        public LifeForce[] lifeForce = new LifeForce[2]; //health, stamina
        #endregion
        void Start()
        {
            behaviour = AiBehaviour.Wandering;
        }

        void Update()
        {
            //if predator/player in aggro radius
            //flee

            //if predator/player in attack radius
            //evade

            //if health low and not in attack radius
            //hide

            //else
            //wander
        }
        #region Behaviours
        void Hide()
        {
            speedBonus = false;
        }
        void OffsetPursuit() //idk what this one means so idk wether for prey or predator
        {

        }
        #endregion
    }
}