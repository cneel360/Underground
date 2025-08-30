using TMPro;
using UnityEngine;

public class healthuimanager : MonoBehaviour
{
    public playerhealth playerhealth;
    public TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = playerhealth.health.ToString();
        
    }
}
