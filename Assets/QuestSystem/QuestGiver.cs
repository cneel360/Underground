using UnityEngine;

public class QuestGiver : MonoBehaviour
{
 public QuestManager manager;
 public QuestObject quest;
 public QuestCardCreator cardCreator;
 public int qid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        quest = manager.GetQuest(qid);
    }
 public void GiveQuest(string missionissuer)
    {
        quest.queststate = 1;
        
        manager.triggerquestupdate(qid);
        manager.flashgivequest(quest.title);
        quest.missionissuer = missionissuer;
        cardCreator.CreateCard(qid);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
