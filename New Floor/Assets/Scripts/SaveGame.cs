using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveGame
{

    //Constructor responsible for saving data
    public static void SaveData()
    {
        //Encrypt data so that output can't be modified outside
        //of game scope
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save_info.sve";
        GameInitializer.ShowIcon(true);
        //stream serialized data to disk
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();

        formatter.Serialize(stream, data);
        stream.Close();
        GameInitializer.ShowIcon(false);
    }

    //Load save file and put in SaveData object
    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/save_info.sve";
        if (File.Exists(path))
        {
            //If there's a save, and deserialize file
            //decrypt serialized data
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            //Trying to load a file that doesn't exist
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
