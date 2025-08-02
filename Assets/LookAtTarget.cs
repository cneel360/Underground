using UnityEngine;

/// <summary>
/// This script makes the GameObject it is attached to constantly face a specified target GameObject.
/// It updates the object's forward direction to point towards the target in every frame.
/// </summary>
public class LookAtTarget : MonoBehaviour
{
    // Public variable to hold the Transform of the target GameObject.
    // You can drag and drop your target object into this slot in the Unity Inspector.
    public Transform target;

    /// <summary>
    /// Update is called once per frame. This is where we will perform the rotation logic.
    /// Using Update() ensures the object is always looking at the target, even if the target moves.
    /// </summary>
    void Update()
    {
        // First, we check if a target has been assigned to prevent a null reference exception.
        if (target != null)
        {
            // 1. Calculate the direction vector.
            // This vector points from the current object's position to the target's position.
            // Subtracting the current position from the target's position gives us the direction.
            Vector3 direction = target.position - transform.position;

            // 2. Normalize the direction vector.
            // While not strictly necessary for transform.forward, it's good practice.
            // It makes the vector's magnitude equal to 1, representing only direction, not distance.
            direction.Normalize();

            // 3. Assign the new direction to the object's forward vector.
            // This is the core of the script. Unity automatically calculates the rotation
            // required to make the object's local Z-axis (its 'forward') point in this new direction.
            transform.right = direction;
        }
    }
}