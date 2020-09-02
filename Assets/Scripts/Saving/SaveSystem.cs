using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void NewCube()
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Path.Combine(Application.dataPath, "SaveFiles/cube.ass");
        FileStream stream;

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Old file deleted.");
        }

        stream = new FileStream(path, FileMode.CreateNew);
        stream.Close();

        Debug.Log("New file created at " + path);
    }

    public static void SaveCube(CubeRotator cube)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Path.Combine(Application.persistentDataPath, "cube.ass");
        FileStream stream = new FileStream(path, FileMode.Create);

        CubeData data = new CubeData(cube);
        formatter.Serialize(stream, data);

        stream.Close();

        Debug.Log("File saved at " + path);
    }

    public static CubeData LoadCube()
    {
        string path = Path.Combine(Application.persistentDataPath, "cube.ass");
        if (File.Exists(path))
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                CubeData data = formatter.Deserialize(stream) as CubeData;
                stream.Close();

                Debug.Log(data + " loaded from " + path);

                return data;
            }
            catch
            {
                Debug.LogError("**ERROR CAUGHT** \n Save file exists at the path specified below but the file contained no related data. \n" + path);
                return null;
            }
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}