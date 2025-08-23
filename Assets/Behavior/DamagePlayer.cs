using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public playerhealth health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            health = collision.gameObject.GetComponent<playerhealth>();
            Debug.Log("Attackedplayer");
            health.Damage(2);
        }
    }
}
