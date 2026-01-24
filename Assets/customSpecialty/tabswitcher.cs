using UnityEngine;

public class tabswitcher : MonoBehaviour
{
    public GameObject currentlyactive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public void Switchtab(GameObject activate)
    {
        currentlyactive.SetActive(false);
        currentlyactive = activate;
        activate.SetActive(true);
    }
}
