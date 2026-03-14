using UnityEngine;

public class testdetailcardquestdataswitching : MonoBehaviour
{
    public QuestManager m;
     public int quest;
    public bool activate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void run()
    {
        m.triggerquestcardswitch(quest);
    }

    // Update is called once per frame
    void Update()
    {
        if(activate)
        {
            activate = false;
            run();
        }
    }
}
