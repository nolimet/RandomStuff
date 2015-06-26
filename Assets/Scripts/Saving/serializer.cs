using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public static class Serialization
{

    public static string saveFolderName = "headFolder";

    public static string SaveLocation(string FileDirectory)
    {
        string saveLocation =  saveFolderName + "/" + FileDirectory + "/";

        if (!Directory.Exists(saveLocation))
        {
            Directory.CreateDirectory(saveLocation);
        }

        return saveLocation;
    }

    public static string GetFileType(string fileName)
    {
        return fileName + ".tkn";
    }

    public static void Save<T>(string fileName, string fileLocation,T token)
    {
        string saveFile = SaveLocation(fileLocation);
        saveFile += GetFileType(fileName);
        
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(saveFile, FileMode.Create, FileAccess.Write, FileShare.None);
        
        formatter.Serialize(stream, token);
        stream.Close();

    }

    public static bool Load<T>(string fileName,string fileLocation, out T outputData)
    {
        string saveFile = SaveLocation(fileLocation);
        saveFile += GetFileType(fileName);

        if (!File.Exists(saveFile))
        {
            outputData = default(T);
            return false;
        }
        IFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(saveFile, FileMode.Open);

        T data = (T)formatter.Deserialize(stream);

        stream.Close();
        outputData = data;
        return true;
    }
}
