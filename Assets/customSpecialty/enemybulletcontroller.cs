using Unity.Collections;
using UnityEngine;

public class enemybulletcontroller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
        [SerializeField] float speed;
    private Rigidbody rb;
 [SerializeField]   private float excepttime = 20f;
   [SerializeField] private  bool istimerrunning;
    public GameObject particlesystem;
    public float DamageNum;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        istimerrunning = true;

        // speed = 10f;
        rb.linearVelocity = transform.forward * speed;
        
        
    }

    void OnCollisionEnter(Collision collision)
    {
         bool selfhittag = collision.gameObject.CompareTag("enemy") == true;
        Instantiate(particlesystem, transform.position, transform.rotation);

         if(!selfhittag){  Debug.Log("[ENEMY BULLETS]Collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            HitPlayer(collision);
        }
            else
            {
                    Destroy(gameObject);
            }
       


        // The 'collision' variable contains info about the hit, like the object hit
      
    }
   void HitPlayer(Collision playercollision)
    {
        Debug.Log("Player has been hit!");
         playerhealth playerHealthSystem = playercollision.gameObject.GetComponent<playerhealth>();
         if(playerHealthSystem != null)
        {
            playerHealthSystem.Damage(DamageNum);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("you fool set playerhealth sytem on bullet!");
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (istimerrunning)
        {
            excepttime -= Time.deltaTime;

        }

        if (excepttime <= 0)
        {
            Debug.Log("Despawned");
            particlesystem.SetActive(true);
            
            Destroy(gameObject);
        }
    }
}
}
