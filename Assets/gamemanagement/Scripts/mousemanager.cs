using UnityEngine;

public class mousemanager : MonoBehaviour
{
  public  bool cursorLocked = true; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

     private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

    private void SetCursorState(bool newState)
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
        
         public  void ChangeCursorState(bool newstate)
    {
        cursorLocked = newstate;
        SetCursorState(cursorLocked);
    }
    
}
