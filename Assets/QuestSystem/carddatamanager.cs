using UnityEngine;
 using TMPro;
 using System;
using UnityEditor.Rendering.BuiltIn.ShaderGraph;
using NUnit.Framework.Internal;
public class carddatamanager : MonoBehaviour
{
    public QuestManager manager;
    public int cardQuestid;
    public QuestObject questoncard;
    
    // ---UI elements--
  public TextMeshProUGUI title;
  public TextMeshProUGUI description; 
  public TextMeshProUGUI difficulty;
 public TextMeshProUGUI missionissuer;
 public TextMeshProUGUI rewarddiscription;
 public TextMeshProUGUI statustext;
    // -- end UI elements--

    void Awake()
    {
        manager =  GameObject.FindGameObjectWithTag("GameManager").GetComponent<QuestManager>();
    }
   void OnEnable()
    {
     if(manager!= null)
        {
            manager.questhasbeenupdated += updatequest;
            manager.SwitchQuest += switchquest;
            Debug.Log("manager subscription questupdated!");
        }
        
        updatequest();
    }
    void OnDisable()
    {
manager.questhasbeenupdated -= updatequest;
manager.SwitchQuest -= switchquest;
         
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questoncard = manager.Questregistry[cardQuestid];
        updatequest();
    }
   public void QuestUpdateCheck(int internalid)
    {
        if(internalid == cardQuestid)
        {
            Debug.Log(" quest upate check ran! on card");
            updatequest();
        }
    }
    void switchquest(int newqid)
    {
        cardQuestid = newqid;
        updatequest();
    }
    void updatequest()
    {
        questoncard = manager.GetQuest(cardQuestid);
        // assign text
        title.text = questoncard.title;
        description.text = questoncard.description;
        difficulty.text = questoncard.complexity.ToString();
        rewarddiscription.text = questoncard.rewarddescription;
        statustext.text= StatusTextGenerator(questoncard.queststate);
        missionissuer.text = questoncard.missionissuer;
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
