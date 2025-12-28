using UnityEngine;

public class locationclient : MonoBehaviour
{
    public locationmanager manager;
    public AudioClip locationsong;
    public string locationname; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            manager.locationmusic = locationsong;
            manager.addplace(locationname);
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            manager.locationmusic = null;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
