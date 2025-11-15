
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class datamanager : MonoBehaviour
{
    //  root references
    public gamedata data;
    public savedataconfig savegameconfig;
    public string jsongamedata;

    // savedata

   // public Vector3 sysposition;
    //public int sysmagizine;
    //public float syshealth;
    //public int[] sysenemylivecount;
    //public float sysplayerprotection;
    //public int[] sysammocrateammocount;
   //public  Vector3[] sysenemypositions;
    // debugtriggers
    public bool debugsavetrigger;
    public bool debugloadtrigger;
    // filestuff
    string basepath;
    string savefilepath;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

  public  void Awake()
    {

        basepath = Application.persistentDataPath;
     //   savegameconfig = new savedataconfig();
        data = new gamedata();
        savefilepath = basepath + "/savefile1.json";
        LoadDataConfig();
        if(savegameconfig.loadfromsave == 1)
        {
            Debug.Log("Loading");
            Load();
        }
    }

  public  void Start()
    {
       
        print(savefilepath);
        print(basepath);
    }

    // Update is called once per frame
public    void Update()
    {
        if (debugsavetrigger)
        {
            Save();
            debugsavetrigger = false;
        }
        if (debugloadtrigger)
        {
            Load();
            debugloadtrigger = false;
        }


    }
 public void Save()
    {
        jsongamedata = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(savefilepath, jsongamedata);
        Debug.Log("game saved");


    }
   public void PreLoad()
    {
        savegameconfig.loadfromsave = 1;
        SaveDataConfig();
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);

    }
  public  void PreNewGame()
    {
        savegameconfig.loadfromsave = 0;
        SaveDataConfig();
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
         
    }
    public void Load()
    {
        if (System.IO.File.Exists(savefilepath))
        {
            jsongamedata = System.IO.File.ReadAllText(savefilepath);
            data = JsonUtility.FromJson<gamedata>(jsongamedata);
        }
        Debug.Log("Data Loaded");
    }

    public void LoadDataConfig()
    {
        string configpath = basepath + "/savedataconfig.json";
        if (System.IO.File.Exists(configpath))
        {
            string jsonholder = System.IO.File.ReadAllText(configpath);
            savegameconfig = JsonUtility.FromJson<savedataconfig>(jsonholder);
        }
        else
        {
            string jsonholder = JsonUtility.ToJson(savegameconfig);
            System.IO.File.WriteAllText(configpath, jsonholder);
            LoadDataConfig();
            Debug.Log("no save data config");

        }

    }
    public void SaveDataConfig()
    {
         string configpath = basepath + "/savedataconfig.json";
        string jsonholder = JsonUtility.ToJson(savegameconfig);
            System.IO.File.WriteAllText(configpath, jsonholder);
    }
}


[System.Serializable]
public class gamedata
{
    /*
    for the arrays assign each object an id and have it load the data from the index (id)
    in the arrays do the same thing for saving but write to its respctive array
    Credits: idea courtesy of rhett
    */
   public Vector3 position;
public int magizine;
     public float health;
  public int[] enemylivecount = new int[25]; 
    
    public float playerprotection;
    
    // **CORRECTED LINE for ammocrateammocount**
    public int[] ammocrateammocount = new int[10]; 

    // **CORRECTED LINE for enemypositions**
    public Vector3[] enemypositions = new Vector3[25];

}
[System.Serializable]
public class savedataconfig{
    public int activesaveslot;
    public int[] saveslots;
    public int loadfromsave;


}