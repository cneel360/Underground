using UnityEngine;
using UnityEngine.SceneManagement;
public class playerhealth : MonoBehaviour

{
    public float healthbuffer;
    public float maxhealth;
    public float protection;
    public float health;
    public float finaldamage;
    public healthcrate HealthCrate;

    //public GameOver gameOvermanager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        healthbuffer = maxhealth - 1;
        if (health <= 0)
        {
            Debug.Log("Player Died");
            //      gameOvermanager.ActivateGameOver(1);
            SceneManager.LoadScene(2);
        }
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
        void OnControllerColliderHit(ControllerColliderHit hit)
    {
       // Debug.Log("something hit by controller");
        if (hit.gameObject.CompareTag("healthcrate"))
        {
          //  Debug.Log("ammocrate hit by controller");
           HealthCrate = hit.gameObject.GetComponent<healthcrate>();
            if (HealthCrate!= null)
            {
                health = HealthCrate.Heal(health, health, maxhealth);
            }
        }
    }
        
    
}
