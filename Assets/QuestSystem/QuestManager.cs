using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using System;

public class QuestManager : MonoBehaviour
{
  public  List<QuestObject> Questregistry = new List<QuestObject>();
    public TextMeshProUGUI givequestnameplateUI;
    public GameObject giveQuestUI;

     public event Action<int> questhasbeenupdated;
    public QuestObject GetQuest( int id)
    {
        return Questregistry[id];
    }// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void triggerquestupdate(int internalid)
    {
        questhasbeenupdated?.Invoke(internalid);
    }

      public void flashgivequest(string titleofquest)
    {
        giveQuestUI.SetActive(true);
        givequestnameplateUI.text = titleofquest;
        Invoke("deactivategivequestui",5f);
    }
    void deactivategivequestui()
    {
        giveQuestUI.SetActive(false);
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
    

