
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SavePlayer(int levelat, float score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(levelat, score);

        formatter.Serialize(stream, data);
        Debug.Log("Progress saved!!");
        stream.Close();
    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.save";
        Debug.Log(path);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData SaveData= formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return SaveData;
        }
        else
        {
            Debug.Log("file not found" + path);
            return null;
        }
    }


}
