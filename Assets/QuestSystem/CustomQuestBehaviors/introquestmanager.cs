using UnityEngine;

public class introquestmanager : MonoBehaviour
{
    public QuestManager qm;
    public QuestObject qo;
    public int qid;
    public bool  hasbeenactivated;    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     qo = qm.GetQuest(qid);   
    }

    // Update is called once per frame
    void Update()
    {
        if(qo.step == qo.numofsteps && !hasbeenactivated)
        {
            qm.flashupdatequest("Finished Activating AA positions");
            qo.description = "all of the AA have been activated";
            hasbeenactivated = true;
        }
    }
}
