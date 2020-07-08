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
            if (lifeForce[0].currentValue <= 0) //if no health
            {
                KillCreature();
            }

            FindClosestCreature();

            DetermineSpeed();

            MoveBehaviour();

            RegenLifeForce(lifeForce[0]); //regen health
            RegenLifeForce(lifeForce[1]); //regen stamina
        }
        void LateUpdate()
        {

        }
        #region Behaviours
        void MoveBehaviour()
        {
            //if grounded, but not that
            //flock if wandering and closestcreature is prey

            if (Vector3.Distance(transform.position, closestCreature.transform.position) <= aggroRadius) //if in aggro radius of player/predator
            {
                if (Vector3.Distance(transform.position, closestCreature.transform.position) <= attackRadius && lifeForce[1].currentValue >= lifeForce[1].maxValue / 4) //if in attack radius of player/predator and have enough stamina
                {
                    Evade(closestCreature);
                }
                else if (lifeForce[0].currentValue < lifeForce[0].maxValue / 4) //if health below 25%
                {
                    Hide();
                }
                else
                {
                    Flee(closestCreature);
                }
            }
            else
            {
                Wander();
            }
        }
        void DetermineSpeed()
        {
            if (speedBonus && lifeForce[1].currentValue > 1) //if fast and stamina
            {
                moveSpeed = fastSpeed;
                lifeForce[1].currentValue -= lifeForce[1].regenValue * 4 * Time.deltaTime; //use stamina when fast
            }
            else //default
            {
                moveSpeed = normalSpeed;
            }
        }
        void Hide()
        {
            if (behaviour != AiBehaviour.Hidden) //update state
            {
                behaviour = AiBehaviour.Hidden;
            }

            speedBonus = false;

            moveSpeed = 0; //no moving while hidden

            //hide it from view somehow
        }
        void Evade(GameObject target)
        {
            //currently won't be called much if at all, address this
            transform.position = Vector3.MoveTowards(transform.position, -target.transform.position, moveSpeed * 4 * Time.deltaTime); //move away from target quickly
            lifeForce[1].currentValue -= lifeForce[1].maxValue / 4; //use 1/4 stamina to evade
        }
        void OffsetPursuit() //idk what this one means so idk whether for prey or predator
        {

        }
        #endregion
    }
}