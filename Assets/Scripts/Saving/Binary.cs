using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Saving
{
    public class Binary
    {
        public static void SaveData(Jim.Player player)
        {
            BinaryFormatter formatter = new BinaryFormatter(); //reference binary formatter
            string path = Application.persistentDataPath + "/" + "Kittens" + ".jpg"; //location to save to
            FileStream stream = new FileStream(path, FileMode.Create); //create file at save path
            Data data = new Data(player); //what data to save
            formatter.Serialize(stream, data); //write and convert to bytes for binary
            stream.Close(); //done
        }
        public static Data LoadData(Jim.Player player)
        {

            string path = Application.persistentDataPath + "/" + "Kittens" + ".jpg"; //location to load from

            if (File.Exists(path)) //write code if exists
            {
                BinaryFormatter formatter = new BinaryFormatter(); //get binary formatter
                FileStream stream = new FileStream(path, FileMode.Open); //get data from path
                Data data = formatter.Deserialize(stream) as Data; //set data to usable values
                stream.Close(); //done
                return data; //send load data to game
            }
            else
            {
                return null;
            }
        }
    }
}