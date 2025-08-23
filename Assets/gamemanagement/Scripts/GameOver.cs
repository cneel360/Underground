
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public GameObject goUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        goUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ActivateGameOver(int gameovertype)
    {
        if (gameovertype == 1)
        {
            Cursor.lockState = CursorLockMode.None;
            goUI.SetActive(true);
    }
    }
    public void Respawn(int gameworld)
    {
        SceneManager.LoadScene(gameworld);
    }
    
}
