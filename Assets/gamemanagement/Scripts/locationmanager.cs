using UnityEngine;
using System.Collections.Generic;
using TMPro;
public class locationmanager : MonoBehaviour
{
       List<string> places = new List<string>(); // Creates an empty list of strings
    public float timer;
    public bool timeisrunning;
    public string name;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 5f;
    }
    void displaytimer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timeisrunning = false;
            nextname();
        }
    }

    // Update is called once per frame
    void Update()
    {
text.text = name;
    }
    public void addplace(string placename)
    {
        places.Add(placename);
      }
    void nextname()
    {
        places.RemoveAt(0);
        if (places.Count != 0)
        {
            name = places[0];
            timeisrunning = true;
        }
        else
        {
            name = "";
        }
    }
}
