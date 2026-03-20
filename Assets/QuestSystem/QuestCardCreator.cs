using UnityEngine;

public class QuestCardCreator : MonoBehaviour
{
    public GameObject cardtemplate;
    public GameObject currentcard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
 public void CreateCard(int questid)
    {
        currentcard = Instantiate(cardtemplate,gameObject.transform);
       ListedCardDataManager newcarddatamanager = currentcard.GetComponent<ListedCardDataManager>();
       newcarddatamanager.cardQuestid = questid;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
