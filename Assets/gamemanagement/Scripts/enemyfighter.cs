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
    public Transform spawnbulletpos;
    public bool cooldownineffect;
    public float shootcooldowntime;
    public int maxammoload;
    Vector3 aimspot;
    Vector3 aimdir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      magazine = 15; 
      cooldownineffect = false; 
    }
    public void aim()
    {
        gameObject.transform.forward = mastersys.oppplayerpos;
       //  troopcontroller.transform.forward = mastersys.playerpos;
        gun.transform.forward = mastersys.oppplayerpos;
        aimgunanimation(1,1);
    }
    public void processaim()
    {
        aimspot = mastersys.playerpos;
          aimdir = (aimspot- spawnbulletpos.position).normalized;
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
    void attemptreload()
    {
        if(magazine> maxammoload)
        {
            mastersys.reloadsoldiers(magazine, 1);
        }
    }
    void tryshoot()
    {
        if(magazine> 0 && !cooldownineffect)
        {
          shoot();  
        }
        if(magazine<= 0)
        {
            mastersys.reloadsoldiers(magazine,1);
        }
    }
    void shoot()
    {
        magazine -=1;
        Debug.Log("Enemy Shooting");
          aimdir = (mastersys.playerpos - spawnbulletpos.position).normalized;
            Instantiate(bulletmodel, spawnbulletpos.position, Quaternion.LookRotation(aimdir, Vector3.up));
        Shootreloadtimereset();
    }
    void Shootreloadtimereset()
    {
        cooldownineffect = true;
        shootcooldowntime = 2.5f;
   //  countdowncooldown();   
    }

     void countdowncooldown()
    {
        if(cooldownineffect){
            if(shootcooldowntime > 0)
        {
              shootcooldowntime -= Time.deltaTime;
        }
        else
        {
            tryshoot();
            cooldownineffect = false;
        }
        }
        
      
    }
    // Update is called once per frame
    void Update()
    {
 init();
        attemptreload();
        countdowncooldown();
    }
}
