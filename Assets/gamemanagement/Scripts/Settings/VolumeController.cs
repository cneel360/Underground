using UnityEngine;

public class VolumeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
public void OnSliderChanged(float value)
    {
        Debug.Log("The new value is: " + value);
        // Add your logic here, e.g., AudioListener.volume = value;
    }
}
