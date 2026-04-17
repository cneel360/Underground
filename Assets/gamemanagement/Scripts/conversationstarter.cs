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
    public AudioClip talkmusic;
    public showinteractionindicator interactionindicator;
    public musicmanager mm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
  private void OnEnable()
    {
        // Use the correct callback names from the documentation
        ConversationManager.OnConversationStarted += ConversationStart;
        ConversationManager.OnConversationEnded += ConversationEnd;
    }

    private void OnDisable()
    {
        ConversationManager.OnConversationStarted -= ConversationStart;
        ConversationManager.OnConversationEnded -= ConversationEnd;
    }

   public void ConversationStart()
    {
     if (dialogeactive)
        {
            mousemanager.ChangeCursorState(false);
            Debug.Log("MY Conversation started!");
            mm.talkmusic = talkmusic;
        }
    }

    public  void ConversationEnd()
    {
        if (dialogeactive)
        {   
            mousemanager.ChangeCursorState(true);
               Debug.Log("Conversation ended!");
        mm.talkmusic = null;
        // Your code here
        }
     
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
                interactionindicator.showindicator(false);
                dialogeactive = true;
                ConversationManager.Instance.StartConversation(myconvo);
                
            }
           if (!dialogeactive)
            {
                  interactionindicator.showindicator(true);
            }
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactionindicator.showindicator(false);
            if (dialogeactive)
            {
                dialogeactive = false;
            ;
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
