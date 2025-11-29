using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "changeanimatorlayerwieght", story: "[animator] [layer] has ts weight set to [value]", category: "Action", id: "148d07ac798465039e8534321a714d53")]
public partial class ChangeanimatorlayerwieghtAction : Action
{
    [SerializeReference] public BlackboardVariable<Animator> Animator;
    [SerializeReference] public BlackboardVariable<int> Layer;
    [SerializeReference] public BlackboardVariable<float> Value;

    protected override Status OnStart()
    {
        Animator.Value.SetLayerWeight(Layer,Value);
        return Status.Running;
    }

   
}

