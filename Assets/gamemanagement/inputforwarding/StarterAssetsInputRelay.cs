using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets; // This allows us to talk to the asset script

public class StarterAssetsInputRelay : MonoBehaviour
{
    private StarterAssetsInputs _starterAssets;

    private void Awake()
    {
        _starterAssets = GetComponent<StarterAssetsInputs>();
    }

    // Link this to the 'Move' event in Player Input
    public void RelayMove(InputAction.CallbackContext context)
    {
        _starterAssets.MoveInput(context.ReadValue<Vector2>());
    }

    // Link this to the 'Look' event
    public void RelayLook(InputAction.CallbackContext context)
    {
        if (_starterAssets.cursorInputForLook)
        {
            _starterAssets.LookInput(context.ReadValue<Vector2>());
        }
    }

    // Link this to 'Jump'
    public void RelayJump(InputAction.CallbackContext context)
    {
        bool isPressed = context.ReadValueAsButton();
_starterAssets.JumpInput(isPressed);
    }

    // Link this to 'Sprint'
    public void RelaySprint(InputAction.CallbackContext context)
    {
        bool isPressed = context.ReadValueAsButton();
_starterAssets.SprintInput(isPressed);
    }
    public void RelayShoot(InputAction.CallbackContext context)
    {
        bool isPressed = context.ReadValueAsButton();
_starterAssets.ShootInput(isPressed);
    }
    public void RelayAim(InputAction.CallbackContext context)
    {
       bool isPressed = context.ReadValueAsButton();
_starterAssets.AimInput(isPressed);
    }
    public void RelayPaused(InputAction.CallbackContext context)
    {
        bool isPressed = context.ReadValueAsButton();
_starterAssets.pauseinput = isPressed;
    }
    public void RelayDialogActive()
    {
        _starterAssets.isDialogActivate = true;
    }
    // Example for your Custom Dialog input
    public void RelayDialog(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _starterAssets.isDialogActivate = true;
            Debug.Log("Relay: Dialog Activated");
        }
    }
}