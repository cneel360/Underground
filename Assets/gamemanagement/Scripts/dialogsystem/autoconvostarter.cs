using UnityEngine;
using DialogueEditor;
using StarterAssets;
using Unity.VisualScripting;
public class autoconvostarter : MonoBehaviour
{
   // public UpdateQuest target0;
        public NPCConversation myconvo;
  //  public StarterAssetsInputs inputs;
    public mousemanager mousemanager;
    public bool dialogeactive;
    public AudioClip talkmusic;
    public musicmanager mm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created void Start()
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
    public void ActivateConvo()
    {
          dialogeactive = true;
                ConversationManager.Instance.StartConversation(myconvo);
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

