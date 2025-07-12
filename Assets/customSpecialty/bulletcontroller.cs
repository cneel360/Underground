using UnityEngine;

public class bulletcontroller : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody rb;
 [SerializeField]   private float excepttime = 20f;
   [SerializeField] private  bool istimerrunning;
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

    void OnTriggerEnter(Collider other)
    {
        speed = 0f;
        Debug.Log("Collided with: " + other);
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
            Destroy(gameObject);
        }
    }
}
