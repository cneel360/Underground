using UnityEngine;

public class showinteractionindicator : MonoBehaviour
{
    public GameObject indicatorobject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void showindicator(bool active)
    {
        indicatorobject.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
