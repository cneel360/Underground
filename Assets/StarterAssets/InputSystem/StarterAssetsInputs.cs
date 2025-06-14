using System.Data.Common;
using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;
        public bool aim;
        public bool AimSwitch;  // This public variable will be updated

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
        // When using Send Messages, this is called when the action is 'performed' (typically on press)
        public void OnMove(InputValue value)
        {
     //       Debug.Log("OnMove called.");
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
          //  Debug.Log("OnLook called.");
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
         //  Debug.Log("OnJump called.");
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
     //       Debug.Log("OnSprint called.");
            SprintInput(value.isPressed);
        }

        // This method will be called when the Aim action is 'performed' (e.g., button pressed down)
        public void OnAim(InputValue value)
        { if (value.isPressed)
            {
                AimInput(true);
           //     Debug.Log("Aim On");
            }
            else if (value.isPressed == false)
            {
                AimInput(false);
               // Debug.Log("Aim off");
            }
            // Debug.Log($"OnAim (Performed) called. InputValue.isPressed: {value.isPressed}");
           // Set aim to true when the action is performed
        }

        // This new method will be called when the Aim action is 'canceled' (e.g., button released)
        public void OnAimCanceled(InputValue value)
        {
            // Debug.Log($"OnAimCanceled called. InputValue.isPressed: {value.isPressed}");
            AimInput(false); // Set aim to false when the action is canceled
        }
#endif

        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }

        public void AimInput(bool newAimState)
        {
            
            aim = newAimState;
            
         //   Debug.Log($"AimInput called. newAimState: {newAimState}, current 'aim' variable: {aim}");
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
        void Update()
        {
            // You don't need continuous logging here for input state, as the OnAim/OnAimCanceled
            // methods handle state changes directly.
        }
    }
}