using UnityEngine;
using UnityEngine.UI;
public class VolumeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
public void ChangeVolume(float value)
    {
        Debug.Log("The new value is: " + value);
         AudioListener.volume = value;
    }
}
