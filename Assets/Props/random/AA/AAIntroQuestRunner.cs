using NUnit.Framework;
using UnityEngine;

public class AAIntroQuestRunner : MonoBehaviour
{
    public interactionbroadcaster ib;
    public showinteractionindicator sii;
    public QuestObject  questobj;
    public int qid;
    public QuestManager questmanager;
    public bool isInBounds;
    public bool questisactive;
    public bool HasBeenActivated;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questobj = questmanager.GetQuest(qid);
        HasBeenActivated = false;
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
        if(questobj.queststate == 1)
        {
            questisactive = true;
        }
        else
        {
            questisactive = false;
        }
        Debug.Log("AA Activation Func Active");
        if (isInBounds && !HasBeenActivated && questisactive)
        {

            questobj.step +=1;
            HasBeenActivated = true;
            Debug.Log("should have activated this AA");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
