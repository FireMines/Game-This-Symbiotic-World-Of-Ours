using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class FileDataHandler
{/*
    private string dirPath = "";
    private string fileName = "";


    public FileDataHandler(string dirPath, string fileName)
    {
        this.dirPath = dirPath;
        this.fileName = fileName;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dirPath, fileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string datatoLoad = "";
                using(FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        datatoLoad = reader.ReadToEnd();
                    }
                }

                //deserialize the data
                loadedData = JsonUtility.FromJson<GameData>(datatoLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error while loading data from " + fullPath + "\n" + e);
            }
            
        }
        return loadedData;


    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dirPath, fileName);

        try
        {
            //create directory path for file
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //convert from data to string
            var datatoStore = new StringBuilder();
            foreach(GameObject obj in data.orbs)
            {
                string json = JsonUtility.ToJson(obj, true);
                datatoStore.Append(json);
            }

            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(datatoStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error while writing to file at " + fullPath + "\n" + e);
        }

    }*/
}
