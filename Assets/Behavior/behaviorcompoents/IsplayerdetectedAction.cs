using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "isplayerdetected", story: "does [controller] detect player on [playerdetected]", category: "Action", id: "925db7c105ad49dc348713b299233ad8")]
public partial class IsplayerdetectedAction : Action
{
    [SerializeReference] public BlackboardVariable<playerdetectedcontroller> Controller;
    [SerializeReference] public BlackboardVariable<bool> Playerdetected;
    protected override Status OnStart()
    {
        if (Controller.Value.isplayerdetected)
        {
            Playerdetected.Value = true;
            return Status.Success;
            
        }
        else if (Controller.Value.isplayerdetected == false)
        {
            Playerdetected.Value = false;
            return Status.Failure;
        }
        else
        {
            return Status.Running;
        }
    }

   
}

