using UnityEngine;

public class playerhealth : MonoBehaviour

{
    public float healthbuffer;
    public float maxhealth;
    public float protection;
    public float health;
    public float finaldamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        healthbuffer = maxhealth -= 1;
    }
    public void Damage(float damagenum)
    {
        finaldamage = damagenum - protection;
        health -= finaldamage;
    }
    public void Heal()
    {

        if (health < healthbuffer)
        {
            health += 1;
        }
    }
        
    
}
