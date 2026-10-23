using UnityEngine;

public class showinteractionindicator : MonoBehaviour
{
    public GameObject indicatorobject;
    public int indicatorcount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void addindicatorrequest(int operand)
    {
        indicatorcount += operand;
        if(indicatorcount >= 1)
        {
            showindicator(true);
                
            
        }
        else
        {
            indicatorcount = 0;
            showindicator(false);
        }
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
