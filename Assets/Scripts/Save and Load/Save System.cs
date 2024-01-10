using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
   /* public static void SavePlayer(PlayerData playerData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        bf.Serialize(stream, playerData);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Player.data";

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = bf.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found. Creating a new one with default values.");

            // Create default PlayerData object with initial values
            PlayerData defaultData = new PlayerData();
            SavePlayer(defaultData);

            return defaultData;
        }
    }*/
}