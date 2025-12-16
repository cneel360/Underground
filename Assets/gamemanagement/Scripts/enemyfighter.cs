using UnityEngine;
using UnityEngine.Rendering;

public class enemyfighter : MonoBehaviour
{
    public int magazine;
    public enemyfightsys mastersys;
    public GameObject gun;
    public GameObject enemyshootroot;
    public GameObject bulletmodel;
    public GameObject troopcontroller;
    public playerdetectedcontroller pdc;
    public Animator EnemyAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public void aim()
    {
        gameObject.transform.forward = mastersys.oppplayerpos;
       //  troopcontroller.transform.forward = mastersys.playerpos;
        gun.transform.forward = mastersys.oppplayerpos;
        aimgunanimation(1,1);
    }
 void  aimgunanimation(int Layer,float Value)
    {
     EnemyAnim.SetLayerWeight(Layer,Value);   
    }

    public void init()
    {
        if (pdc.shootrange)
        {
            aim(); 
            tryshoot();
        }
        else
        {
            aimgunanimation(1,0);
        }
       
    }
    void tryshoot()
    {
        if(magazine> 0)
        {
          shoot();  
        }
    }
    void shoot()
    {
        Debug.Log("Enemy Shooting");
    }
    // Update is called once per frame
    void Update()
    {
 init();
        
    }
}
