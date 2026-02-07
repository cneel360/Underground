using UnityEngine;

public class QuestGiver : MonoBehaviour
{
 public QuestManager manager;
 public QuestObject quest;
 public int qid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        quest = manager.GetQuest(qid);
    }
 public void GiveQuest()
    {
        quest.queststate = 1;
        manager.triggerquestupdate(qid);
        manager.flashgivequest(quest.title);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
