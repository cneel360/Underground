using StarterAssets;
using UnityEngine;


public class playerpauseclient : MonoBehaviour
{
    public pausemanager pause;
   public ThirdPersonController playercontroller;
public PlayerShootingSystem playershoot;
   public bool activepause;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
void updatecomponentactivestate()
    {
        playercontroller.enabled = activepause;
        playershoot.enabled = activepause;
    }
    // Update is called once per frame
    void Update()
    {
        activepause = !pause.gamepaused;
        updatecomponentactivestate();
        
    }
}
