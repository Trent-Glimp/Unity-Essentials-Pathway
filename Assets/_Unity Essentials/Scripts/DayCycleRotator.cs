using UnityEngine;

/// <summary>
/// Slowly rotates a directional light to simulate the passage of a day.
/// Attach this script to a Directional Light GameObject.
/// </summary>
public class DayCycleRotator : MonoBehaviour
{
    [Tooltip("How many real-time seconds a full 360° rotation (one day) takes.")]
    public float dayDurationInSeconds = 120f;   // default: 2 minutes

    void Update()
    {
        // Avoid division by zero
        if (dayDurationInSeconds <= 0f)
            return;

        // Calculate the angle to rotate this frame
        float rotationThisFrame = 360f / dayDurationInSeconds * Time.deltaTime;

        // Rotate around the X axis (right vector) so the sun rises and sets.
        // Adjust the axis if your scene uses a different orientation.
        transform.Rotate(Vector3.right, rotationThisFrame);
    }
}