using UnityEngine;

public class healthcrate : MonoBehaviour
{
    public int healthnum;


    void Start()
    {

    }
    public int Heal(int health)
    {        health += healthnum;
       healthnum = 0;
        return health;
   }


    // Update is called once per frame
    void Update()
    {
        
    }
}
