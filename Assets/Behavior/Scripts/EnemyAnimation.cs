using UnityEngine;
using UnityEngine.AI;

// Note: NUnit.Framework is typically only needed for testing and can be removed 
// unless you are specifically writing unit tests for this script.

public class EnemyAnimation : MonoBehaviour
{
    // Assigned in Inspector for safety and easy configuration
    public NavMeshAgent agent;
    public Animator animator;
    
    // Configurable values
    [Header("Movement")]
    [Tooltip("The minimum velocity magnitude to be considered 'moving'.")]
    private const float VelocityThreshold = 0.1f;
    private const float DefaultAgentSpeed = 3.5f;

    public bool hasplayerbeendetected;
   // [Header("Shot Clock")]
    //[Tooltip("Duration the agent is slowed after a hit before reverting to patrol animations.")]
    private const float ShotClockDuration = 5f;
    private float shotClockTimer;
    private bool isShotClockRunning;
    public float agentspeed;
  //  [Header("State")]
    // noscopeanimoverride: true means we are in default patrol/idle animation loop (controlled by Update).
    // false means an event (like being scoped) is overriding the animation.
    public bool noScopeAnimOverride;
    
    // Calculated every frame
    public bool isAgentMoving;


    void Start()
    {
        // Safety checks: Ensure components are assigned
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        if (animator == null) animator = GetComponent<Animator>();

        if (agent == null || animator == null)
        {
            Debug.LogError("NavMeshAgent or Animator component is missing on " + gameObject.name);
            enabled = false; // Disable script if critical components are missing
            return;
        }
            
        // Initialize state
        noScopeAnimOverride = true; // Enemy starts in default patrol mode
        shotClockTimer = ShotClockDuration;
        isShotClockRunning = false;
        agent.speed = DefaultAgentSpeed;
    }

 void Update()
    {
        isAgentMoving = agent.velocity.magnitude > VelocityThreshold;
        agentspeed = agent.speed;
          
        // --- Animation State Management ---
        if (noScopeAnimOverride)
        {
            // If in default patrol mode, set animation based on movement
            float patrolValue = isAgentMoving ? 0.5f : 0.0f;
            animator.SetFloat("patrol", patrolValue);
        }
        else if (!isAgentMoving)
        {
            // If an override is active but the agent has stopped moving, 
            // force the animation back to idle (0f).
            animator.SetFloat("patrol", 0f);
        }

        // --- Shot Clock Timer ---
        if (isShotClockRunning)
        {
            shotClockTimer -= Time.deltaTime;
        }

        // Check timer using <= for reliable float comparison (FIXED BUG)
        if (shotClockTimer <= 0f)
        {
            isShotClockRunning = false;
            noScopeAnimOverride = true; // Revert to patrol/default state
            agent.speed = DefaultAgentSpeed; // Reset speed
            shotClockTimer = ShotClockDuration; // Reset timer
        }
        if (hasplayerbeendetected && !isShotClockRunning)
        {
            agent.speed = 5f;
            animator.SetFloat("patrol", .75f);
        }
        else if (!hasplayerbeendetected)
        {
            noScopeAnimOverride = true;
              float patrolValue = isAgentMoving ? 0.5f : 0.0f;
            animator.SetFloat("patrol", patrolValue);
            
        }
    }


    // Called when a trigger collider enters the enemy's trigger collider.
    public void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Something in scope"); 
        
        if (other.gameObject.CompareTag("AimSphere"))
        {
            // Debug.Log("TARGET - INSCOPE");
            
            // Only engage scope-speed if not currently recovering from a hit
            if (!isShotClockRunning)
            {
                noScopeAnimOverride = false; // Override patrol logic
                
                // Set speed and animation based on current movement state
                if (isAgentMoving)
                {
                    agent.speed = 5.0f;
                    animator.SetFloat("patrol", 0.7f);
                }
                else
                {
                    // If not moving, keep speed low and force idle animation
                    agent.speed = DefaultAgentSpeed; 
                    animator.SetFloat("patrol", 0f);
                }
            }
        }
        
        // Note: Logic for 'playerweapon' is kept in OnCollisionEnter for impacts.
    }

    // Called when the target leaves the enemy's trigger collider.
    void OnTriggerExit(Collider other)
    {
        if (hasplayerbeendetected == false)
        {
            if (other.gameObject.CompareTag("AimSphere"))
        {
            // If the scope trigger is left, revert to default patrol state
            noScopeAnimOverride = true;

            // Only reset speed if the shot clock isn't currently forcing a slower speed
            if (!isShotClockRunning)
            {
                agent.speed = DefaultAgentSpeed;
            }
        }
        }
        // Must check tag to prevent unrelated triggers from resetting state (FIXED BUG)
        
    }

    // Called when a solid collider hits the enemy (used for impact/weapon hits).
    public void OnCollisionEnter(Collision collision) // CORRECTED TYPO (FIXED BUG)
    {
        if (collision.gameObject.CompareTag("playerweapon"))
        {
            // Debug.Log("TARGET - hit");
            
            // On hit, start the slow-down and shot clock
            noScopeAnimOverride = false; // Take control away from patrol update loop
            isShotClockRunning = true;
            shotClockTimer = ShotClockDuration; // Ensure timer resets immediately on hit
            agent.speed = 2.0f; // Slow down speed
            
            // Set animation based on movement when hit
            if (isAgentMoving)
            {
                animator.SetFloat("patrol", 0.3f);
            }
            else 
            {
                animator.SetFloat("patrol", 0f);
            }
        } 
    }
}