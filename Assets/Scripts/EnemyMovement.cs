using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 movementDirection = Vector3.right; // Default movement direction
    private float movementSpeed = 3f; // Default movement speed
    private float movementDistance = 10f; // Default movement distance

    void Update()
    {
        // Move the enemy in the specified direction
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);

        // Check if the enemy has reached the end of its movement distance
        if (Mathf.Abs(transform.position.x) >= movementDistance / 2f)
        {
            // Reverse the movement direction
            movementDirection *= -1;
        }
    }

    // Method to set the movement direction
    public void SetMovementDirection(Vector3 direction)
    {
        movementDirection = direction.normalized;
    }

    // Method to set the movement speed
    public void SetMovementSpeed(float speed)
    {
        movementSpeed = speed;
    }

    // Method to set the movement distance
    public void SetMovementDistance(float distance)
    {
        movementDistance = Mathf.Abs(distance); // Ensure distance is positive
    }
}