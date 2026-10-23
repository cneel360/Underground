using UnityEngine;

public class AAIntroQuestRunner : MonoBehaviour
{
    public interactionbroadcaster ib;
    public showinteractionindicator sii;
    public QuestObject  questobj;
    public int qid;
    public QuestManager questmanager;
    public bool isInBounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questobj = questmanager.GetQuest(qid);
    }
    void OnEnable()
    {
        ib.interacttrying += AA_Activate;
    }
    void OnDisable(){
        ib.interacttrying -= AA_Activate;
    }
    void OnTriggerEnter(Collider other)
    {
        sii.addindicatorrequest(1);
        isInBounds = true;
        
    }
    void OnTriggerExit(Collider other)
    {
        sii.addindicatorrequest(-1);
        isInBounds = false;
    }
    void AA_Activate()
    {
        if (isInBounds)
        {
            questobj.step +=1;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
