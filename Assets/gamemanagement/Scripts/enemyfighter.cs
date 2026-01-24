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
   public float shoottimeout;
    Vector3 aimdir;
bool running_aim_anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      magazine = 15; 
      cooldownineffect = false; 
    }
    public void aim()
    {
            aimdir = (mastersys.playerpos - spawnbulletpos.position).normalized;

         Vector3 directionToPlayer = (mastersys.playerpos - transform.position).normalized;
           Debug.DrawRay(spawnbulletpos.position, aimdir * 10f, Color.red, 10f);
           
        gameObject.transform.forward = directionToPlayer;
       //  troopcontroller.transform.forward = mastersys.playerpos;
        gun.transform.forward = directionToPlayer;
        aimgunanimation(1,1f,5f);
        
    }
    public void processaim()
    {
        aimspot = mastersys.playerpos;
          aimdir = (aimspot- spawnbulletpos.position).normalized;
    }
 void  aimgunanimation(int Layer,float Value, float speed)
    {
     float currentWeight = EnemyAnim.GetLayerWeight(Layer);
    float newWeight = Mathf.Lerp(currentWeight,Value, Time.deltaTime * speed);
    EnemyAnim.SetLayerWeight(Layer, newWeight);
    
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
            aimgunanimation(1,0,5f);
        }

       
    }
    void attemptreload()
    {
        if(magazine < maxammoload)
        {
       magazine =  mastersys.reloadsoldiers(magazine, 1);
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
        magazine =  mastersys.reloadsoldiers(magazine,5);
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
        shootcooldowntime = shoottimeout;
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
      //  attemptreload();
        countdowncooldown();
    }
}
