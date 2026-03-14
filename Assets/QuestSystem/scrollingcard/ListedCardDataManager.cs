using UnityEngine;
using TMPro;
using System;
public class ListedCardDataManager : MonoBehaviour
{
      public QuestManager manager;
    public int cardQuestid;
    public QuestObject questoncard;
  public TextMeshProUGUI title;
  public TextMeshProUGUI statustext;

    void Awake()
    {
        manager =  GameObject.FindGameObjectWithTag("GameManager").GetComponent<QuestManager>();
    }
     void OnEnable()
    {
     if(manager!= null)
        {
            manager.questhasbeenupdated += updatequest;
            Debug.Log("manager subscription questupdated!");
        }
        
        updatequest();
    }
    void OnDisable()
    {
manager.questhasbeenupdated -= updatequest;
         
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void updatequest()
    {
        
    }
     string StatusTextGenerator(int statecode)
    {
        if(statecode == 0)
        {
            return "Unissued";
        }
         else if( statecode == 1)
        {
            return "Active";
        } else if ( statecode == 2)
        {
            return  "Accomplished";
        }
        else
        {
             return "TOP SECRET- DEVELOPER EYES ONLY- INTERNAL ACCESS REQUIRED";
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
