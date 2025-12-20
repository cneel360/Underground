using UnityEngine;

public class enemyfightsys : MonoBehaviour
{
    public GameObject player;
    public Transform playertransform;
    public Vector3 playerpos;
     public Vector3 oppplayerpos;

     public int ammopool;
     public int maxstockpool;
   public float pooltimout;
public bool timoutineffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initplayertransform();
    }
void UpdatePlayerTransform()
    {
      playerpos = playertransform.position;
      oppplayerpos = playerpos * -1;
    }
  void initplayertransform()
    {
          playertransform = player.transform;
    }
    void reloadammostockpile()
    {
        if(ammopool <= maxstockpool && !timoutineffect)
        {
              ammopool += 1;
              Shootreloadtimereset();
        }
    }
  public void reloadsoldiers( int magvar,  int withdrawnum)
    {
    if (withdrawnum < ammopool)
        {
            ammopool -= withdrawnum;
        magvar += withdrawnum;  
        Debug.Log("ENEMY RELOADED"); 
        }
    }
     void Shootreloadtimereset()
    {
        timoutineffect = true;
      pooltimout = 2.5f;
     countdowncooldown();   
    }
    void countdowncooldown()
    {
        if (timoutineffect)
        {
          if(pooltimout > 0)
        {
              pooltimout -= Time.deltaTime;
        }
        else
        {
            timoutineffect = false;
        }
        
        }
        
    }
    public int aimcheck(playerdetectedcontroller pdc, Transform enemytransform) 
    {
        if (pdc.shootrange)
        {
            enemytransform.forward = playerpos;
            return 1;
            
        }
        else
        {
             return 0;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        reloadammostockpile();
        countdowncooldown();
        UpdatePlayerTransform();
    }
}
