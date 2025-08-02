using UnityEngine;

public class bulletcontroller : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody rb;
 [SerializeField]   private float excepttime = 20f;
   [SerializeField] private  bool istimerrunning;
    public GameObject particlesystem;
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
        // The 'collision' variable contains info about the hit, like the object hit
        Debug.Log("Collided with: " + collision.gameObject.name);
        Instantiate(particlesystem, transform.position, transform.rotation);
        Destroy(gameObject);
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
