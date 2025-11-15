using StarterAssets;
using UnityEngine;

public class pausemanager : MonoBehaviour
{
    public StarterAssetsInputs inputmanager;
    public mousemanager cursormanage;
    public GameObject pauseui;
    public bool gamepaused;
    void Awake()
    {
        Time.timeScale = 1;
            }
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
        Time.timeScale = 0;

     //   inputmanager.pauseinput = false;
    }
    public void EndPause()
    {
        Debug.Log("Game Unpaused");
        pauseui.SetActive(false);
        cursormanage.ChangeCursorState(true);
        Time.timeScale = 1;
    }
}
