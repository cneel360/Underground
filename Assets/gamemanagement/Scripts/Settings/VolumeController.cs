using UnityEngine;
using UnityEngine.UI;
public class VolumeController : MonoBehaviour
{
   public  Settingsdatamanager datamanager;
     public Slider volumeSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeVolume(datamanager.data.volume);
        volumeSlider.value = datamanager.data.volume;
    }
public void ChangeVolume(float value)
    {
        Debug.Log("The new value is: " + value);
         AudioListener.volume = value;
    }
    public void SaveValue(float value)
    {
        datamanager.data.volume = value;
    }
}
