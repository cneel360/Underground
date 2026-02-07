using UnityEngine;
 using TMPro;
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
    // -- end UI elements--

    void Awake()
    {
        manager =  GameObject.FindGameObjectWithTag("GameManager").GetComponent<QuestManager>();
    }
    void OnEnable()
    {
        manager.questhasbeenupdated += QuestUpdateCheck;
    }
    void OnDisable()
    {
      manager.questhasbeenupdated -= QuestUpdateCheck;  
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        questoncard = manager.Questregistry[cardQuestid];
        updatequest();
    }
    void QuestUpdateCheck(int internalid)
    {
        if(internalid == cardQuestid)
        {
            updatequest();
        }
    }
    void updatequest()
    {
        questoncard = manager.GetQuest(cardQuestid);
        // assign text
        title.text = questoncard.title;
        description.text = questoncard.description;
        difficulty.text = questoncard.complexity.ToString();
        rewarddiscription.text = questoncard.rewarddescription;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
