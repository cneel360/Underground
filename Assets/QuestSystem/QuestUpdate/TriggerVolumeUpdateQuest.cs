using UnityEngine;

public class TriggerVolumeUpdateQuest : MonoBehaviour
{
    public UpdateQuest updateQuest;
    public string checktag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(checktag))
        {
            updateQuest.ActivateQuest();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
