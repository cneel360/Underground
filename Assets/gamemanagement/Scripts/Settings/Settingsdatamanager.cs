using JetBrains.Annotations;
using UnityEngine;
using System;
using UnityEngine.Rendering;
public class Settingsdatamanager : MonoBehaviour
{
    public string basepath;
    public string filepath;
    public settingsdata data;
    public string jsondata;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
      basepath = Application.persistentDataPath;
      filepath = basepath + "/basicgamesettings.json";
      if (System.IO.File.Exists(filepath))
        {
            Load();
        }
        else
        {
            Generatebasedata();
            Save();
        }
       
    }
    void Start()
    {
        
    }
       void Load()
    {
       
        {
            jsondata = System.IO.File.ReadAllText(filepath);
            data = JsonUtility.FromJson<settingsdata>(jsondata); 
            Debug.Log("Data Loaded");
        }
       
    }
    void Generatebasedata()
    {
        data.volume = 1;
    }
     public void Save()
    {
        jsondata = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(filepath, jsondata);
        Debug.Log("game saved");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public  class settingsdata
{
    public float volume;
}
