using UnityEngine;

public class enemyfighter : MonoBehaviour
{
    public int magazine;
    public enemyfightsys mastersys;
    public GameObject gun;
    public GameObject enemyshootroot;
    public GameObject bulletmodel;
    public GameObject troopcontroller;
    public playerdetectedcontroller pdc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void aim()
    {
        gameObject.transform.forward = mastersys.oppplayerpos;
       //  troopcontroller.transform.forward = mastersys.playerpos;
        gun.transform.forward = mastersys.oppplayerpos;
    }

    public void init()
    {
        if (pdc.shootrange)
        {
            aim(); 
        }
       
    }
    // Update is called once per frame
    void Update()
    {
 init();
        
    }
}
