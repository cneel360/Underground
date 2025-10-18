using UnityEngine;

public class datamanager : MonoBehaviour
{
    public static datamanager Instance;
    public gamedata data;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    Vector3 position;
    int magizine;
    float health;
    int[] enemylivecount;
    float playerprotection;
    int[] ammocrateammocount;


}