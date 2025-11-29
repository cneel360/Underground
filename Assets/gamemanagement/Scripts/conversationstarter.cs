using UnityEngine;
using DialogueEditor;
using StarterAssets;
using JetBrains.Annotations;
public class conversationstarter : MonoBehaviour
{
    public NPCConversation myconvo;
    public StarterAssetsInputs inputs;
    public mousemanager mousemanager;
    public bool dialogeactive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        Debug.Log("trigger stay on dialog "+other.tag);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Dialog player tag triggered");
            if (inputs.isDialogActivate)
            {
                inputs.isDialogActivate = false;
                mousemanager.ChangeCursorState(false);
                dialogeactive = true;
                ConversationManager.Instance.StartConversation(myconvo);
                
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialogeactive)
            {
                dialogeactive = false;
               mousemanager.ChangeCursorState(true);
            }
        }
     
    
}
public void EndDialoge()
    {
           if (dialogeactive)
            {
                dialogeactive = false;
               mousemanager.ChangeCursorState(true);
            }
    }
            
        
}
