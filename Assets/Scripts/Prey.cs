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

        }

        void Update()
        {

        }
        #region Behaviours
        void Hide()
        {
            //if fleeing and gets far away enough
            //waits and then wander
            behaviour = AiBehaviour.Hidden;
        }
        void OffsetPursuit() //idk what this one means so idk wether for prey or predator
        {

        }
        #endregion
    }
}