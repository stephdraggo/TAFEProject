using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controls
{
    [AddComponentMenu("Game Systems/Controls/Interact")]
    public class Interact : MonoBehaviour
    {
        #region Variables
        [Header("Player and Camera connection")]
        public GameObject player;
        public GameObject mainCam, dialogue;
        #endregion
        #region Start
        void Start()
        {

        }
        #endregion
        #region Update   
        void Update()
        {
            if (Input.GetKeyDown(Controls.Keybinds.keys["Interact"]))
            {
                Ray interact; //create a ray
                interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); //shoot ray at centre of main camera view
                RaycastHit hitInfo; //create reference to thing hit
                if (Physics.Raycast(interact, out hitInfo, 10)) //if thing is within 10 units, 10 metres?
                {
                    #region NPC
                    if (hitInfo.collider.CompareTag("NPC")) //thing is tagged NPC
                    {
                        Debug.Log("Talk to NPC");
                        //dialogue enable = true;
                        if (hitInfo.collider.GetComponent<Dialogue.Dialogue>()) //if it has a dialogue option
                        {
                            hitInfo.collider.GetComponent<Dialogue.Dialogue>().showDialogue = true; //bool set true
                            //use SceneControl here for panels
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            Camera.main.GetComponent<MouseLook>().enabled = false; //explain?
                            GetComponent<MouseLook>().enabled = false; //explain?
                        }
                        /*
                        if (hitInfo.collider.GetComponent<OptionLinearDialogue>())
                        {
                            hitInfo.collider.GetComponent<OptionLinearDialogue>().showDlg = true;
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            Camera.main.GetComponent<MouseLock>().enabled = false;
                            GetComponent<MouseLock>().enabled = false;
                        }
                        if (hitInfo.collider.GetComponent<ApprovalDialogue>())
                        {
                            hitInfo.collider.GetComponent<ApprovalDialogue>().showDlg = true;
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            Camera.main.GetComponent<MouseLock>().enabled = false;
                            GetComponent<MouseLock>().enabled = false;
                        }
                        if (hitInfo.collider.GetComponent<DialogueControl>())
                        {
                            hitInfo.collider.GetComponent<DialogueControl>().showDialogue = true;
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            Camera.main.GetComponent<MouseLock>().enabled = false;
                            GetComponent<MouseLock>().enabled = false;
                        }
                        */
                    }
                    #endregion
                    #region Item
                    if (hitInfo.collider.CompareTag("Item")) //thing is tagged Item
                    {
                        Debug.Log("Pick up item");
                        ItemControl itemControl = hitInfo.transform.GetComponent<ItemControl>(); //script needed
                        if (itemControl != null)
                        {
                            itemControl.OnCollection();
                        }
                    }
                    #endregion
                    #region Chest
                    if (hitInfo.collider.CompareTag("Chest")) //thing is tagged Chest
                    {
                        Chest chest = hitInfo.transform.GetComponent<Chest>(); //script needed
                        if (chest != null)
                        {
                            LinearInventory.currentChest = chest;
                            chest.showChestInv = true;
                            LinearInventory.showInventory = true;
                            Cursor.lockState = CursorLockMode.None;
                            Cursor.visible = true;
                            Camera.main.GetComponent<MouseLock>().enabled = false;
                            GetComponent<MouseLock>().enabled = false;
                        }
                    }
                    #endregion
                }
            }
        }
        #endregion
    }
}