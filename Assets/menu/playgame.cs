using UnityEngine;
using UnityEngine.SceneManagement;
public class playgame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void PlayScene(int playscene)
    {
        SceneManager.LoadScene(playscene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
