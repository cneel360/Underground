using UnityEngine;

public class bulletcontroller : MonoBehaviour
{
    float speed;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 10f;
        rb.linearVelocity = transform.forward * speed;
        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
