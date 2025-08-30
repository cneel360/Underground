using UnityEngine;
using UnityEngine.SceneManagement;

public class GOreset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void gotoscene(int scenenum)
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(scenenum);
    
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
