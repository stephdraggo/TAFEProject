using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jim //it's life
{
    [AddComponentMenu("Game Systems/Life/Predator")]
    public class Predator : Life
    {
        #region Variables
        public float attackDamage;
        public GameObject[] territoryPatrol;
        public GameObject player;
        public int patrolIndex;
        public LifeForce[] lifeForce = new LifeForce[2]; //health, stamina
        #endregion
        void Start()
        {
            behaviour = AiBehaviour.Patrolling;
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

        #region Behaviours
        void MoveBehaviour()
        {
            //if grounded, but not that
            if (lifeForce[0].currentValue < lifeForce[0].maxValue / 4)//if health below 25%
            {
                if (Vector3.Distance(transform.position, player.transform.position) <= aggroRadius) //if in aggro radius of player
                {
                    Flee(player); //flee from player
                }
                else if (Vector3.Distance(transform.position, closestCreature.transform.position) <= aggroRadius / 3) //if prey in 1/3 aggro radius
                {
                    if (Vector3.Distance(transform.position, closestCreature.transform.position) <= attackRadius) //if prey in attack radius
                    {
                        Attack(closestCreature);
                    }
                    else
                    {
                        Chase(closestCreature);
                    }
                }
                else
                {
                    Wander();
                }
            }
            else if (Vector3.Distance(transform.position, closestCreature.transform.position) <= aggroRadius) //if prey/player in aggro radius
            {
                if (Vector3.Distance(transform.position, closestCreature.transform.position) <= attackRadius) //if prey/player in attack radius
                {
                    Attack(closestCreature);
                }
                else
                {
                    Chase(closestCreature);
                }
            }
            else
            {
                Patrol();
            }
        }
        public void DetermineSpeed()
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
        void Patrol()
        {
            if (behaviour != AiBehaviour.Patrolling) //update state
            {
                behaviour = AiBehaviour.Patrolling;
            }

            speedBonus = false; //no speed bonus for patrol

            if (patrolIndex >= territoryPatrol.Length) //if reached last patrol location
            {
                patrolIndex = 0; //reset target
            }
            else
            {
                MoveInTargetDirection(territoryPatrol[patrolIndex]);
                if (Vector3.Distance(transform.position, territoryPatrol[patrolIndex].transform.position) <= 0.01f) //if close enough 
                {
                    patrolIndex++; //move to next patrol location
                }
            }

        }
        void Chase(GameObject target)
        {
            if (behaviour != AiBehaviour.Chasing) //update state
            {
                behaviour = AiBehaviour.Chasing;
            }

            speedBonus = true; //speed bonus while chasing

            MoveInTargetDirection(target);
        }
        void Attack(GameObject target)
        {
            speedBonus = false;

            if (target.TryGetComponent(out Prey creature)) //if target is Prey
            {
                creature.lifeForce[0].currentValue -= attackDamage; //take health away from target
            }
            else if (target.TryGetComponent(out Player playerLife)) //if target is player
            {
                playerLife.lifeForce[0].currentValue -= attackDamage; //take health away from player
            }

            lifeForce[0].currentValue += attackDamage / 5; //heal according to 1/5 damage dealt
            lifeForce[1].currentValue -= lifeForce[1].maxValue / 5; //use up 1/5 max stamina
        }
        void OffsetPursuit() //idk what this one means so idk whether for prey or predator
        {

        }
        #endregion
    }
}