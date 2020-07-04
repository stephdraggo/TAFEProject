using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Saving
{
    public class SaveAndLoad : MonoBehaviour
    {
        public Jim.Player player;
        void Awake()
        {
            if (!PlayerPrefs.HasKey("Loaded"))
            {
                FirstLoad();
                PlayerPrefs.SetInt("Loaded", 0);
                Save();
            }
            else
            {
                Load();
            }
        }
        void Update()
        {
#if UNITY_EDITOR //for testing only
            if (Input.GetKeyDown(KeyCode.K)) //K to save
            {
                Save();
            }
#endif
        }
        void FirstLoad()
        {
            for (int i = 0; i < player.lifeForce.Length; i++)
            {
                player.lifeForce[i].maxValue = 100;
                player.lifeForce[i].currentValue = 100;
                player.transform.position = new Vector3(10, 1, 10);
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
                player.checkPoint = GameObject.Find("Start Position").GetComponent<Transform>(); //fix later
            }
        }
        public void Save()
        {
            Binary.SaveData(player);
        }
        public void Load()
        {
            Data data = Binary.LoadData(player);
            player.name = data.playerName;
            player.checkPoint = GameObject.Find(data.checkPoint).GetComponent<Transform>(); //fix later
            player.level = data.level;
            for (int i = 0; i < player.lifeForce.Length; i++)
            {
                player.lifeForce[i].currentValue = data.statusCurrentValues[i];
                player.lifeForce[i].maxValue = data.statusMaxValues[i];
            }
            player.transform.position = new Vector3(data.pX, data.pY, data.pZ);
            player.transform.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rW);
            player.currentExp = data.currentExp;
            player.maxExp = data.maxExp;
            player.neededExp = data.neededExp;
        }
    }
}