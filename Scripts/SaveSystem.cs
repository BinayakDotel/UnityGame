using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(Texture2D texture)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";

        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, texture);
        stream.Close();
    }

    public static Texture2D LoadData()
    {
        string path = Application.persistentDataPath + "/player.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Texture2D texture= formatter.Deserialize(stream) as Texture2D;

            stream.Close();
            return texture;
        }
        else
        {
            Debug.LogError("File not Found");
            return null;
        }
    }
}
