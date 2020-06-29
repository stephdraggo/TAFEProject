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
        public float jumpSpeed = 8f, crouchSpeed = 2f, sprintSpeed = 10f, gravity = 100f, horizontal, vertical;
        public bool usingKeybinds;
        public string[] baseKeys;
        public Controls.Keybinds keybinds;
        [Header("Death")]
        public AudioSource deathSound;
        public AudioSource gameSound;
        public GameObject deathPanel, hudPanel;
        #endregion
        void Start()
        {
            behaviour = AiBehaviour.Player;
            speedBonus = false;
            characterController = GetComponent<CharacterController>();
            if (Controls.Keybinds.keys.Count < 1)
            {
                keybinds.DefaultKeys();
            }
            deathPanel.SetActive(false);
            hudPanel.SetActive(true);
            deathSound = GetComponent<AudioSource>();
        }
        void Update()
        {
            Move();
            if (lifeForce[0].currentValue <= 0)
            {
                Death();
            }
            for (int i = 0; i < 3; i++)
            {
                lifeForce[i].displayImage.fillAmount = Mathf.Clamp01(lifeForce[i].currentValue / lifeForce[i].maxValue);
            }
            
            
        }
        void OnTriggerEnter(Collider collision) //cactus
        {
            if (collision.gameObject.CompareTag("Hurts"))
            {
                lifeForce[0].currentValue -= 20f;
            }
        }
        #region Functions
        void Move()
        {
            if (characterController.isGrounded)
            {
                if (!keybinds)
                {
                    moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")));

                }
                else
                {
                    Direction();
                    moveDirection = transform.TransformDirection(new Vector3(horizontal, 0, vertical));
                }
                Speed();
                moveDirection *= moveSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
        }
        void Direction()
        {
            horizontal = 0;
            vertical = 0;
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
            if (Input.GetKey(Controls.Keybinds.keys["Jump"]))
            {
                moveDirection.y = jumpSpeed;
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
                moveSpeed = 5f;
            }
        }
        public void Death()
        {
            Debug.Log("You died");
            gameSound.Stop();
            deathSound.Play();
            deathPanel.SetActive(true);
            hudPanel.SetActive(false);
            lifeForce[0].currentValue = lifeForce[0].maxValue;
            transform.position = new Vector3(10, 0, 10);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        public void Respawn()
        {
            Debug.Log("Respawning");
            deathSound.Stop();
            gameSound.Play();
            deathPanel.SetActive(false);
            hudPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        public void Pause() //none
        {
            //Pause not implemented
            /*
            if (Input.GetKeyDown(Controls.Keybinds.keys["Pause"]))
            {
                if (SceneControl.isPaused)
                {
                    hudPanel.SetActive(false);
                }
                else
                {
                    hudPanel.SetActive(true);
                }
            }
            */
        }
        public void Inventory() //none
        {
            //Inventory not implemented
            /*
            if (Input.GetKeyDown(Controls.Keybinds.keys["Inventory"]))
            {
                if (invPanel.activeSelf)
                {
                    invPanel.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                else
                {
                    invPanel.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            */
        }
        #endregion
    }
}
