using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Events;
public class UpdateQuest : MonoBehaviour
{
   public QuestManager manager;
   public int questid;
   public QuestObject currentQuest;
   public int step;
   public int numberofstepstoadvance;
   public int statusneeded; 
   public bool AdvancestepCount;

   // DO Something
   public UnityEvent function;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentQuest = manager.GetQuest(questid);
    }
    public void ActivateQuest()
    {
        if(currentQuest.queststate == statusneeded && currentQuest.step == step)
        {
            if(function != null)
            {
                function.Invoke();
            }
            if (AdvancestepCount)
            {
                step += numberofstepstoadvance;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
