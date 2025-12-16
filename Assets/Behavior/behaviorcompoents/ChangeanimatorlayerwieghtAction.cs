using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using Unity.VisualScripting;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "changeanimatorlayerwieght", story: "[animator] [layer] has ts weight set to [value] and potentially uses a [lerp] over a certain amount of [lerptime]", category: "Action", id: "148d07ac798465039e8534321a714d53")]
public partial class ChangeanimatorlayerwieghtAction : Action
{
    [SerializeReference] public BlackboardVariable<Animator> Animator;
    [SerializeReference] public BlackboardVariable<int> Layer;
    [SerializeReference] public BlackboardVariable<float> Value;
    [SerializeReference] public BlackboardVariable<bool> Lerp;
    [SerializeReference] public BlackboardVariable<float> LerpTime;
    public int startvalue = 0;

    protected override Status OnStart()
    {

        Animator.Value.SetLayerWeight(Layer,Value);

        return Status.Success;
    }
    

   
}

