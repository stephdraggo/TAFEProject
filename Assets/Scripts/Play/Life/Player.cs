using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jim //it's life
{
    [AddComponentMenu("Game Systems/Life/Player")]
    [RequireComponent(typeof(CharacterController))]

    public class Player : Life
    {
        #region Variables
        public LifeForce[] lifeForce = new LifeForce[3]; //health, mana, stamina
        public Stats[] stats = new Stats[6]; //str, end, agi, cha, aur, tho
        [Header("Player Variables")]
        public CharacterController characterController;
        private Vector3 moveDirection = Vector3.zero;
        public float jumpSpeed = 8f, crouchSpeed = 2f, sprintSpeed = 10f, gravity = 100f, horizontal, vertical, currentExp, neededExp, maxExp;
        public bool usingKeybinds;
        public static bool isDead;
        public string[] baseKeys;
        public Controls.Keybinds keybinds;
        public Quest.Control quest;
        //need checkpoints
        [Header("Death")]
        public AudioSource deathSound;
        public AudioSource gameSound;
        #endregion
        void Start()
        {
            behaviour = AiBehaviour.Player;
            speedBonus = false;
            isDead = false;
            characterController = GetComponent<CharacterController>();
            if (Controls.Keybinds.keys.Count < 1)
            {
                keybinds.DefaultKeys();
            }
            deathSound = GetComponent<AudioSource>();
        }
        void Update()
        {
            if (!isDead) //if alive
            {
                Move();
                if (lifeForce[0].currentValue <= 0) //if no health
                {
                    Death();
                }
            }
            for (int i = 0; i < 3; i++) //for all life forces
            {
                lifeForce[i].displayImage.fillAmount = Mathf.Clamp01(lifeForce[i].currentValue / lifeForce[i].maxValue); //update life force display
            }
        }
        void OnTriggerEnter(Collider collision) //example cactus
        {
            if (collision.gameObject.CompareTag("Hurts"))
            {
                lifeForce[0].currentValue -= 20f; //value for testing purposes only
            }
        }
        #region Functions
        void Move()
        {
            if (characterController.isGrounded) //if on ground
            {
                if (!keybinds) //if there are no saved keybinds
                {
                    moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"))); //default movement
                }
                else //if there are saved keybinds
                {
                    Direction(); //determine direction
                    moveDirection = transform.TransformDirection(new Vector3(horizontal, 0, vertical)); //movement in given direction
                }
                Speed(); //determine speed based on type
                moveDirection *= moveSpeed; //movement according to speed
            }
            moveDirection.y -= gravity * Time.deltaTime; //include gravity
            characterController.Move(moveDirection * Time.deltaTime); //now you can move
        }
        void Direction()
        {
            horizontal = 0; //left/right
            vertical = 0; //forward/backward
            if (Input.GetKey(Controls.Keybinds.keys["Forward"]))
            {
                vertical++;
            }
            if (Input.GetKey(Controls.Keybinds.keys["Backward"]))
            {
                vertical--;
            }
            if (Input.GetKey(Controls.Keybinds.keys["Right"]))
            {
                horizontal++;
            }
            if (Input.GetKey(Controls.Keybinds.keys["Left"]))
            {
                horizontal--;
            }
        }
        void Speed()
        {
            if (Input.GetKeyDown(Controls.Keybinds.keys["Jump"])) //if key 'jump'
            {
                moveDirection.y = jumpSpeed; //jump speed up
            }
            else if (Input.GetKey(Controls.Keybinds.keys["Sprint"]))
            {
                moveSpeed = sprintSpeed;
            }
            else if (Input.GetKey(Controls.Keybinds.keys["Crouch"]))
            {
                moveSpeed = crouchSpeed;
            }
            else
            {
                moveSpeed = 5f; //default speed
            }
        }
        public void Death()
        {
            Debug.Log("You died");
            isDead = true; //bool set true
            gameSound.Stop();
            deathSound.Play();
            lifeForce[0].currentValue = lifeForce[0].maxValue; //refill health, change to refill all stats with for loop
            transform.position = new Vector3(10, 0, 10); //change this to last checkpoint location
        }
        public void Respawn()
        {
            Debug.Log("Respawning");
            isDead = false; //bool set false
            deathSound.Stop();
            gameSound.Play();
            //put panels and pause functions from SceneControl onto Respawn button
        }
        #endregion
    }
}
