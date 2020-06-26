using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jim //it's life
{
    public class Predator : Life
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
        void Patrol()
        {
            behaviour = AiBehaviour.Patrolling;
        }
        void Chase()
        {
            behaviour = AiBehaviour.Chasing;
        }
        void Attack()
        {

        }
        void OffsetPursuit() //idk what this one means so idk wether for prey or predator
        {

        }
        #endregion
    }
}