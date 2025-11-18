using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class dialogmanager : MonoBehaviour
{
    public GameObject dialogboxui;
    public GameObject dialogindicator;
    public TextMeshProUGUI  dialogtext;
    public List<string> activedialog;
  public int maxdialoglength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       dialogboxui.SetActive(false);
       dialogindicator.SetActive(false);
    }
  void  DisplayDialog()
    {
     dialogboxui.SetActive(true);
     dialogtext.text = activedialog[1];        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
