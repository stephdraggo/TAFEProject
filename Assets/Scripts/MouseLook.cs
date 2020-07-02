using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controls
{
    [AddComponentMenu("Game Systems/Controls/Mouse Look")]
    public class MouseLook : MonoBehaviour
    {
        #region Variables
        public enum RotationAxis
        {
            MouseH,
            MouseV
        }
        [Header("Rotation Variables")]
        public RotationAxis axis = RotationAxis.MouseH;
        [Range(0, 200)]
        public float sensitivity = 100, minY = -60, maxY = 60;
        private float _rotY;
        private Settings.SceneControl sceneControl;
        #endregion
        void Start()
        {
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().freezeRotation = true;
            }
            if (GetComponent<Camera>())
            {
                axis = RotationAxis.MouseV;
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            if (sceneControl.gamePaused)
            {
                if (axis == RotationAxis.MouseH)
                {
                    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime, 0);
                }
                else
                {
                    _rotY += Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
                    _rotY = Mathf.Clamp(_rotY, minY, maxY);
                    transform.localEulerAngles = new Vector3(-_rotY, 0, 0);
                }
            }
        }
    }
}