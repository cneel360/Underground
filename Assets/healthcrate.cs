using UnityEngine;

public class healthcrate : MonoBehaviour
{
    public float healthnum;


    void Start()
    {

    }
    public float Heal(float health, float currenthealth, float maxhealth)
    {        
        float healthdifferntial=  maxhealth - currenthealth;
        if(healthnum > healthdifferntial)
        {
             health += healthdifferntial;
            healthnum -= healthdifferntial;
        }  else
        {
            health += healthnum;
       healthnum = 0;
        }
        
        return health;
   }


    // Update is called once per frame
    void Update()
    {
        
    }
}
