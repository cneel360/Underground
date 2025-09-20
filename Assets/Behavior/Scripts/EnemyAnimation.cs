using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimation : MonoBehaviour
{
    public NavMeshAgent agent;

    // A reference to the Animator component.
    public Animator animator;
    private float velothreshhold;
    public bool isAgentMoving;
    public bool noscopeanimoverride;
    //  private bool ismoving;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velothreshhold = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        isAgentMoving = agent.velocity.magnitude > velothreshhold;
        if (isAgentMoving && noscopeanimoverride)
        {
            animator.SetFloat("patrol", .5f);
        }
        else if (isAgentMoving == false && noscopeanimoverride  )
        {
            animator.SetFloat("patrol", 0f);
        }
        

    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(" Something in scope");
        if (other.gameObject.CompareTag("AimSphere"))
        {
            Debug.Log(" TARGET - INSCOPE");
            if (isAgentMoving)
            {
                noscopeanimoverride = false;
                agent.speed = 5;
                animator.SetFloat("patrol", .7f);
            }


        }
    }
    void OnTriggerExit(Collider other)
    {
        noscopeanimoverride = true;
        agent.speed = 3.5f;
        
    }
}
