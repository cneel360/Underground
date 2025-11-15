using UnityEngine;
# if UNITY_EDITOR
using UnityEditor;
# endif
public class quitmanager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void QuitGame()
    {
        Debug.Log("Game Quitting....");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
