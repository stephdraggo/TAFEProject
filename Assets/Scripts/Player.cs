using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jim //it's life
{
    public class Player : Life
    {
        #region Variables
        public LifeForce[] lifeForce = new LifeForce[3]; //health, mana, stamina
        public Stats[] stats = new Stats[6]; //str, end, agi, cha, aur, tho
        #endregion
        void Start()
        {
            behaviour = AiBehaviour.Player;
            speedBonus = false;
        }
        void Update()
        {

        }
    }
}
