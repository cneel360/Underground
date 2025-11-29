using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "isplayerdetected", story: "does [controller] detect [player] on [playerdetected] and is enemy in [shootingrange]", category: "Action", id: "925db7c105ad49dc348713b299233ad8")]
public partial class IsplayerdetectedAction : Action
{
    [SerializeReference] public BlackboardVariable<playerdetectedcontroller> Controller;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<bool> Playerdetected;
    [SerializeReference] public BlackboardVariable<bool> Shootingrange;
    protected override Status OnStart()
    {
        Debug.Log("Enemy:Scope in action");
        if (Controller.Value.isplayerdetected)
        {
            Debug.Log("Found the player");
            Playerdetected.Value = true;
         //   return Status.Success;

        }
        else  
        {
            Debug.Log("Enemy:Cant find player");
            Playerdetected.Value = false;
          
        }
       
       if (Controller.Value.shootrange)
        {
            Shootingrange.Value = true;
        }
        else
        {
             Shootingrange.Value = false; 
        }
         return Status.Success;
    }

   
}

