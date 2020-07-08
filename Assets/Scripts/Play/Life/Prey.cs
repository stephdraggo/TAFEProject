using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jim //it's life
{
    [AddComponentMenu("Game Systems/Life/Prey")]
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
        void LateUpdate()
        {
            RegenLifeForce(lifeForce[0]); //regen health
            RegenLifeForce(lifeForce[1]); //regen stamina
        }
        #region Behaviours
        void Hide()
        {
            if (behaviour != AiBehaviour.Hidden) //update state
            {
                behaviour = AiBehaviour.Hidden;
            }
            speedBonus = false;
        }
        void OffsetPursuit() //idk what this one means so idk whether for prey or predator
        {

        }
        #endregion
    }
}