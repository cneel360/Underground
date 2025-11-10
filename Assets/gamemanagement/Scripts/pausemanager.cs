using StarterAssets;
using UnityEngine;

public class pausemanager : MonoBehaviour
{
    public StarterAssetsInputs inputmanager;
    public mousemanager cursormanage;
    public GameObject pauseui;
    public bool gamepaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputmanager.pauseinput)
        {
            togglegamepaused();

            if (gamepaused)
            {
                OnPause();
            }
            else
            {
                EndPause();
            } 
        }
    }
    public void togglegamepaused()
    {
        gamepaused = !gamepaused;
        inputmanager.pauseinput = false;
    }

    public void OnPause()
    {
        Debug.Log("game paused");
        pauseui.SetActive(true);
        cursormanage.ChangeCursorState(false);

     //   inputmanager.pauseinput = false;
    }
    public void EndPause()
    {
        Debug.Log("Game Unpaused");
        pauseui.SetActive(false);
        cursormanage.ChangeCursorState(true);
    }
}
