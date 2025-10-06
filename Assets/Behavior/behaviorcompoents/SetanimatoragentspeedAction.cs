using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "setanimatoragentspeed", story: "set [agentspeed] from [enemyanimation]", category: "Action", id: "d7a1cead3a95e4bcd263fbf58e73c4f8")]
public partial class SetanimatoragentspeedAction : Action
{
    [SerializeReference] public BlackboardVariable<float> Agentspeed;
    [SerializeReference] public BlackboardVariable<EnemyAnimation> Enemyanimation;

    protected override Status OnStart()
    {
        Agentspeed.Value = Enemyanimation.Value.agentspeed;
        return Status.Success;
    }

  
}

