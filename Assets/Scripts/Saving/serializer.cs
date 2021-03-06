﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public static class Serialization
{
    #region fileSaveSettings
    public enum fileTypes
    {
        wave,
        save,
        settings
    }
    
    public static string saveFolderName = "headFolder";
    readonly public static Dictionary<fileTypes, string> fileExstentions = new Dictionary<fileTypes, string>
        {
            { fileTypes.save,       ".sav"  },
            { fileTypes.settings,   ".set"  },
            { fileTypes.wave,       ".wav"  }
        },

        FileLocations = new Dictionary<fileTypes, string>
        {
            { fileTypes.save,       "Save"      },
            { fileTypes.settings,   "Settings"  },
            { fileTypes.wave,       "Waves"     }
        };
    #endregion

    public static string SaveLocation(fileTypes fileType)
    {
        string saveLocation = saveFolderName + "/" + FileLocations[fileType] + "/";

        if (!Directory.Exists(saveLocation))
        {
            Directory.CreateDirectory(saveLocation);
        }

        return saveLocation;
    }

    public static string GetFileType(string fileName, fileTypes fileType)
    {
        return fileName + fileExstentions[fileType];
    }

    public static void Save<T>(string fileName,fileTypes fileType, T token)
    {
        string saveFile = SaveLocation(fileType);
        saveFile += GetFileType(fileName, fileType);

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(saveFile, FileMode.Create, FileAccess.Write, FileShare.None);

        formatter.Serialize(stream, token);
        stream.Close();

    }

    public static bool Load<T>(string fileName, fileTypes fileType, out T outputData)
    {
        string saveFile = SaveLocation(fileType);
        saveFile += GetFileType(fileName, fileType);

        if (!File.Exists(saveFile))
        {
            outputData = default(T);
            return false;
        }
        IFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(saveFile, FileMode.Open);
        try
        {
            T data = (T)formatter.Deserialize(stream);

            stream.Close();
            outputData = data;
            return true;
        }
        finally
        {
            outputData = default(T);
        }
    }
}
