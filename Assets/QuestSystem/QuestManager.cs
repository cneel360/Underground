using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
  public  List<QuestObject> Questregistry = new List<QuestObject>();
    
    
    public QuestObject GetQuest( int id)
    {
        return Questregistry[id];
    }// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public QuestObject GetQuestFromRegister(int id)
    {
        QuestObject CurrentQuest;
        CurrentQuest = new QuestObject();
        for ( int i=0; i <= Questregistry.Count; i++)
        {
         CurrentQuest= Questregistry[i];
            if(CurrentQuest.questid == id)
            {
                break;
            }
        }
        return CurrentQuest;
        }
   
    
    }

    // Update is called once per frame
    

