
using UnityEngine;

public class datamanager : MonoBehaviour
{
    //  root references
    public gamedata data;
    public string jsongamedata;

    // savedata

    public Vector3 sysposition;
    public int sysmagizine;
    public float syshealth;
    public int[] sysenemylivecount;
    public float sysplayerprotection;
    public int[] sysammocrateammocount;
   public  Vector3[] sysenemypositions;
    // debugtriggers
    public bool debugsavetrigger;
    public bool debugloadtrigger;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {

        data = new gamedata();

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
    void Save()
    {
        jsongamedata = JsonUtility.ToJson(data);
        Debug.Log("game saved");

    }
    void Load()
    {
        data = JsonUtility.FromJson<gamedata>(jsongamedata);
        Debug.Log("Data Loaded");
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
     public int[] enemylivecount;
     public float playerprotection;
    public int[] ammocrateammocount;

   public Vector3[] enemypositions;

}