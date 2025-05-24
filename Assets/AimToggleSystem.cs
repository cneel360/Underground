using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class AimToggleSystem : MonoBehaviour
{
    [Header("References")]
    public CinemachineVirtualCamera aimCamera;

    private PlayerInput playerInput;
    private InputAction aimAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        // Ensure the PlayerInput is using actions
        if (playerInput == null || playerInput.actions == null)
        {
            Debug.LogError("PlayerInput component or InputActions is missing!");
            return;
        }

        // Grab the "Aim" action
        aimAction = playerInput.actions["aim"];

        if (aimAction == null)
        {
            Debug.LogError("No input action named 'Aim' found!");
            return;
        }

        aimAction.performed += OnAimStarted;
        aimAction.canceled += OnAimCanceled;
    }

    private void OnDestroy()
    {
        // Unsubscribe to prevent memory leaks
        if (aimAction != null)
        {
            aimAction.performed -= OnAimStarted;
            aimAction.canceled -= OnAimCanceled;
        }
    }

    private void OnAimStarted(InputAction.CallbackContext context)
    {
        if (aimCamera != null)
        {
            aimCamera.gameObject.SetActive(true);
            Debug.Log("Aiming started.");
        }
    }

    private void OnAimCanceled(InputAction.CallbackContext context)
    {
        if (aimCamera != null)
        {
            aimCamera.gameObject.SetActive(false);
            Debug.Log("Aiming canceled.");
        }
    }
}
