using TMPro;
using UnityEngine;

public class BuuletnumUI : MonoBehaviour
{
    public PlayerShootingSystem shotingsys;
    public int bulnum;
    public TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulnum = shotingsys.magazine;
        string bulstring = bulnum.ToString();
        text.text = bulstring;
    }
}
