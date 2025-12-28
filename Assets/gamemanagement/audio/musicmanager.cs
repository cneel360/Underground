using JetBrains.Annotations;
using UnityEngine;

public class musicmanager : MonoBehaviour
{
    public AudioClip locationmusic;
    public AudioClip enemymusic;
    public AudioClip standardmusic;
    
    public AudioClip musicplaying;
    public AudioSource speaker;
    public locationmanager location;
    public AudioClip previousClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      previousClip = null;  
    }
void SelectMusic()
    {
        if(enemymusic != null)
        {
            musicplaying = enemymusic;
        } else if(locationmusic != null)
        {
            musicplaying = locationmusic;
        }
        else
        {
            musicplaying = standardmusic;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        SelectMusic();
        if(musicplaying != previousClip)
        {
            speaker.clip = musicplaying;
            speaker.Play();
            previousClip = musicplaying;
        }
    }
}
