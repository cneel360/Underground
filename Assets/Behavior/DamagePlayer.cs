using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public float DamageNum;

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            playerhealth playerHealthScript = collision.gameObject.GetComponent<playerhealth>();
            Destroy(gameObject);

            if (playerHealthScript != null)
            {
                Debug.Log("Attacked player!");
                playerHealthScript.Damage(DamageNum);

            }
        }
        if (collision.gameObject.CompareTag("playerweapon"))
        {
            Destroy(gameObject);
        }
        
        
    }
}