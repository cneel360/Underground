using UnityEngine;

public class DebugMessageWriter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void WriteDebugMessage(string message)
    {
        Debug.Log(message);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
