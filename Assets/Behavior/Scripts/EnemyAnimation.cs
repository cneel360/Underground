using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Manages enemy animation states based on NavMeshAgent movement and player interactions.
/// Handles patrol, scoped, and hit recovery states with appropriate speed and animation adjustments.
/// </summary>
public class EnemyAnimation : MonoBehaviour
{
    #region Inspector Fields
    
    [Header("Components")]
    [Tooltip("NavMesh agent controlling enemy movement")]
    public NavMeshAgent agent;
    
    [Tooltip("Animator controlling enemy animations")]
    public Animator animator;
    
    [Header("Detection State")]
    [Tooltip("Whether the player has been detected by this enemy")]
    public bool hasPlayerBeenDetected;
    
    #endregion
    
    #region Constants
    
    // Movement thresholds
    private const float VELOCITY_THRESHOLD = 0.1f;
    
    // Speed values
    private const float DEFAULT_SPEED = 3.5f;
    private const float PURSUIT_SPEED = 4.0f;
    private const float SCOPED_SPEED = 5.0f;
    private const float HIT_RECOVERY_SPEED = 2.0f;
    
    // Animation values
    private const float ANIM_IDLE = 0.0f;
    private const float ANIM_HIT_RECOVERY = 0.3f;
    private const float ANIM_PATROL = 0.5f;
    private const float ANIM_SCOPED = 0.7f;
    private const float ANIM_PURSUIT = 0.75f;
    
    // Timing
    private const float SHOT_CLOCK_DURATION = 5.0f;
    
    #endregion
    
    #region State Variables
    
    // Animation state control
    private bool isInDefaultPatrolMode;
    
    // Hit recovery tracking
    private bool isRecoveringFromHit;
    private float hitRecoveryTimer;
    
    // Cached calculations
    private bool isAgentMoving;
    private bool wasAgentMoving; // NEW: Track previous movement state
    
    #endregion
    
    #region Public Properties (for debugging & external access)
    
    public bool IsAgentMoving => isAgentMoving;
    public float AgentSpeed => agent != null ? agent.speed : 0f;
    public bool NoScopeAnimOverride => isInDefaultPatrolMode;
    
    // Legacy property names for backward compatibility with existing scripts
    public float agentspeed 
    { 
        get => agent != null ? agent.speed : 0f; 
        set { if (agent != null) agent.speed = value; }
    }
    public bool hasplayerbeendetected 
    { 
        get => hasPlayerBeenDetected; 
        set => hasPlayerBeenDetected = value; 
    }
    
    #endregion
    
    #region Unity Lifecycle
    
    void Start()
    {
        InitializeComponents();
        InitializeState();
    }
    
    void Update()
    {
        UpdateMovementState();
        UpdateHitRecoveryTimer();
        UpdateAnimationState();
    }
    
    #endregion
    
    #region Initialization
    
    private void InitializeComponents()
    {
        // Auto-assign components if not set in inspector
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        if (animator == null) animator = GetComponent<Animator>();
        
        // Validate critical components
        if (agent == null || animator == null)
        {
            Debug.LogError($"[EnemyAnimation] Missing required components on {gameObject.name}");
            enabled = false;
        }
    }
    
    private void InitializeState()
    {
        isInDefaultPatrolMode = true;
        isRecoveringFromHit = false;
        hitRecoveryTimer = SHOT_CLOCK_DURATION;
        agent.speed = DEFAULT_SPEED;
        wasAgentMoving = false;
    }
    
    #endregion
    
    #region Update Logic
    
    private void UpdateMovementState()
    {
        wasAgentMoving = isAgentMoving; // Store previous state
        isAgentMoving = agent.velocity.magnitude > VELOCITY_THRESHOLD;
    }
    
    private void UpdateHitRecoveryTimer()
    {
        if (!isRecoveringFromHit) return;
        
        hitRecoveryTimer -= Time.deltaTime;
        
        if (hitRecoveryTimer <= 0f)
        {
            EndHitRecovery();
        }
    }
    
    private void UpdateAnimationState()
    {
        // Priority order: Hit Recovery > Scoped > Pursuit > Default Patrol
        
        if (isRecoveringFromHit)
        {
            // Update hit recovery animation based on movement
            float animValue = isAgentMoving ? ANIM_HIT_RECOVERY : ANIM_IDLE;
            SetAnimation(animValue);
            return;
        }
        
        if (!isInDefaultPatrolMode)
        {
            // Currently scoped or in another override state
            if (isAgentMoving)
            {
                SetAnimation(ANIM_SCOPED);
            }
            else
            {
                SetAnimation(ANIM_IDLE);
            }
            return;
        }
        
        // Default patrol mode handling
        if (hasPlayerBeenDetected)
        {
            SetPursuitState();
        }
        else
        {
            ApplyDefaultPatrolAnimation();
        }
    }
    
    #endregion
    
    #region State Management
    
    private void SetDefaultPatrolState()
    {
        isInDefaultPatrolMode = true;
        float animValue = isAgentMoving ? ANIM_PATROL : ANIM_IDLE;
        SetAnimation(animValue);
    }
    
    private void SetPursuitState()
    {
        agent.speed = PURSUIT_SPEED; // Always maintain pursuit speed when player is detected
        
        if (isAgentMoving)
        {
            // Enemy is moving - play pursuit animation
            SetAnimation(ANIM_PURSUIT);
        }
        else
        {
            // Enemy has stopped (caught up or reached destination)
            SetAnimation(ANIM_IDLE);
        }
        
        // Check if enemy just started moving again (transition from idle to moving)
        if (isAgentMoving && !wasAgentMoving)
        {
            // Enemy resumed movement - ensure pursuit animation plays
            SetAnimation(ANIM_PURSUIT);
        }
    }
    
    private void SetScopedState()
    {
        if (isRecoveringFromHit) return;
        
        isInDefaultPatrolMode = false;
        
        if (isAgentMoving)
        {
            agent.speed = SCOPED_SPEED;
            SetAnimation(ANIM_SCOPED);
        }
        else
        {
            agent.speed = DEFAULT_SPEED;
            SetAnimation(ANIM_IDLE);
        }
    }
    
    private void StartHitRecovery()
    {
        isInDefaultPatrolMode = false;
        isRecoveringFromHit = true;
        hitRecoveryTimer = SHOT_CLOCK_DURATION;
        agent.speed = HIT_RECOVERY_SPEED;
        
        float animValue = isAgentMoving ? ANIM_HIT_RECOVERY : ANIM_IDLE;
        SetAnimation(animValue);
    }
    
    private void EndHitRecovery()
    {
        isRecoveringFromHit = false;
        isInDefaultPatrolMode = true;
        agent.speed = DEFAULT_SPEED;
        hitRecoveryTimer = SHOT_CLOCK_DURATION;
    }
    
    #endregion
    
    #region Collision & Trigger Handlers
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AimSphere"))
        {
            SetScopedState();
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (hasPlayerBeenDetected) return;
        
        if (other.gameObject.CompareTag("AimSphere"))
        {
            isInDefaultPatrolMode = true;
            
            if (!isRecoveringFromHit)
            {
                agent.speed = DEFAULT_SPEED;
            }
        }
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("playerweapon"))
        {
            StartHitRecovery();
        }
    }
    
    #endregion
    
    #region Helper Methods
    
    private void ApplyDefaultPatrolAnimation()
    {
        float animValue = isAgentMoving ? ANIM_PATROL : ANIM_IDLE;
        SetAnimation(animValue);
    }
    
    private void SetAnimation(float value)
    {
        animator.SetFloat("patrol", value);
    }
    
    public void DefaultPatrol()
    {
        SetDefaultPatrolState();
    }
    
    #endregion
}