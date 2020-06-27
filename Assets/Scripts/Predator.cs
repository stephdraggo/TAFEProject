using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jim //it's life
{
    public class Predator : Life
    {
        #region Variables
        public Vector3[] territoryPatrol;
        public LifeForce[] lifeForce = new LifeForce[2]; //health, stamina
        #endregion
        void Start()
        {
            behaviour = AiBehaviour.Patrolling;
        }

        void Update()
        {
            //if prey/player in aggro radius and not hidden
            //Chase

            //if prey/player in attack radius
            //attack

            //if health low and in aggro radius of player
            //flee

            //if health low
            //wander

            //else
            //patrol
        }
        #region Behaviours
        void Patrol()
        {
            speedBonus = false;
            for (int i = 0; i < territoryPatrol.Length; i++)
            {
                //cycle points
                //remember index when interupted
            }
        }
        void Chase()
        {
            speedBonus = true;
        }
        void Attack()
        {
            speedBonus = false;
        }
        void OffsetPursuit() //idk what this one means so idk wether for prey or predator
        {

        }
        #endregion
    }
}