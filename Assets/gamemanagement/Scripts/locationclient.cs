using UnityEngine;

public class locationclient : MonoBehaviour
{
    public locationmanager manager;
    public string locationname; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            manager.addplace(locationname);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
