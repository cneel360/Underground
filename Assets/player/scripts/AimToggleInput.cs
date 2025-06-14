using UnityEngine;
using UnityEngine.InputSystem; // Required for the New Input System

/// <summary>
/// This script toggles the 'aim' boolean variable in the StarterAssetsInputs script
/// using an input action defined in the New Input System.
/// It's designed to work with a setup where PlayerShootingSystem reads the 'aim' state
/// directly from StarterAssetsInputs.
/// </summary>
public class AimToggleInput : MonoBehaviour
{
    public bool aim;

    
          public void OnAim(InputValue isAim)
    {
        // isAim.isPressed returns true if the action is currently active (being pressed).
        // It returns false if the action is no longer active (released).
        aim = isAim.isPressed;

        // You can add debug logs to see the state change in the console.
        if (aim)
        {
          //  Debug.Log("Aim action is PRESSED!");
        }
        else
        {
         //   Debug.Log("Aim action is RELEASED!");
        }
    }
    
}