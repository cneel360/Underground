using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;

public class enemypauseclient : MonoBehaviour
{
     public pausemanager pause;
    public BehaviorGraphAgent enemyai;
    public EnemyAnimation eanim;
    public NavMeshAgent nav_agent;
    public Animator anim_control;
       public bool activepause;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    void updatecomponentactivestate()
    {
        enemyai.enabled = activepause;
        eanim.enabled = activepause;
        nav_agent.enabled = activepause;
        anim_control.enabled = activepause;
    }

    // Update is called once per frame
    void Update()
    {
         activepause = !pause.gamepaused;
        updatecomponentactivestate();
        
    }
}
