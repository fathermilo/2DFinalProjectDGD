using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject crashEffectPrefab; // Reference to the crash effect prefab
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy collides with the player
        if (other.CompareTag("Player"))
        {
            // Instantiate the crash effect at the enemy's position
            Instantiate(crashEffectPrefab, transform.position, Quaternion.identity);

            // Trigger the crash effect animation
            animator.SetTrigger("Crash");

            // Destroy the player GameObject
            Destroy(other.gameObject);

            // Destroy the enemy GameObject after a short delay to allow the animation to play
            Destroy(gameObject, 0.5f); // Adjust delay as needed
        }
    }
}