using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    [Tooltip("How long each side of the square should be.")]
    public float sideLength = 5f;

    [Tooltip("How fast the robo-vacuum moves and turns.")]
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private int sidesCompleted = 0;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Check distance traveled on current side
        if (Vector3.Distance(startPosition, transform.position) >= sideLength)
        {
            // Snap to exact corner position
            Vector3 direction = (transform.position - startPosition).normalized;
            transform.position = startPosition + direction * sideLength;

            // Turn 90 degrees to the left
            transform.Rotate(0f, -90f, 0f);

            // Reset start position for next side
            startPosition = transform.position;

            sidesCompleted++;

            // Optional reset after full square
            if (sidesCompleted >= 4)
            {
                sidesCompleted = 0;
            }
        }
    }
}