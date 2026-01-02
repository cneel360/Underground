using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public float health;
    public GameObject bloodparticlesystem;
    float finaldamage;
    public float protection;
    public float maxhealth;
    public float healthbuffer;
  public enemydeathcontroller deathcon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
public void Damage(float damagenum)
    {
        finaldamage = damagenum - protection;
        health -= finaldamage;
          Instantiate(bloodparticlesystem, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        healthbuffer = maxhealth - 1;
        if (health <= 0)
        {
            Debug.Log("Enemy Combatant Died");
         deathcon.Die();
        
            
        }
    }
     public void Heal()
    {

        if (health < healthbuffer)
        {
            health += 1;
        }
    }
}
