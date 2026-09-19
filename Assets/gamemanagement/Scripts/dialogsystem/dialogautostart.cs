using UnityEngine;

public class dialogautostart : MonoBehaviour
{
    public autoconvostarter starter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
{
    // Check if the object entering the trigger is the player
    if (other.CompareTag("Player"))
    {
        starter.ActivateConvo();
    }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
