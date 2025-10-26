using UnityEngine;
using System.Collections.Generic;
using TMPro;
public class locationmanager : MonoBehaviour
{
      public List<string> places = new List<string>(); // Creates an empty list of strings
    public float timer;
    public bool timeisrunning;
    public string name;
    public string newname;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 5f;
    }
    void displaytimer()
    {
        if (timeisrunning)
        {
            timer -= Time.deltaTime;
        }
        
        if (timer <= 0)
        {
            timeisrunning = false;
            nextname();
        }
    }

    // Update is called once per frame
    void Update()
    {
        displaytimer();
        text.text = name;
      
    }
    public void addplace(string placename)
    {
        newname = placename;
        nextname();
      }
    void nextname()
    {
        name = "";
        if(newname == "")
        {
            name = "";
            
        }
        else
        {
            name = newname;
              newname = "";
            timer = 5f;
        timeisrunning = true;
        }
       
        
       
       
    }
}
