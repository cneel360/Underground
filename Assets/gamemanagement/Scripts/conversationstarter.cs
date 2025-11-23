using UnityEngine;
using DialogueEditor;
using StarterAssets;
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
        if (other.CompareTag("Player"))
        {
            if (inputs.isDialogActivate)
            {
                inputs.isDialogActivate = false;
                mousemanager.cursorLocked = false;
                dialogeactive = true;
                
            }
        }
    }
}
