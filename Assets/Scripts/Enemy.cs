using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        // Get the GameManager component
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Border"))
        {
            // Check if the target is "Asteroid" and destroys the object
            if (gameObject.CompareTag("Asteroid"))
            {
                Destroy(gameObject);
            }
            // Check if the target is "Enemy" and ends the game
            else if (gameObject.CompareTag("Enemy"))
            {
                gameManager.GameOver();
                Destroy(gameObject); // Also destroy the enemy to avoid multiple triggers
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            // Check if the collided object is an asteroid
            if (gameObject.CompareTag("Asteroid"))
            {
                Destroy(gameObject); // Destroy the asteroid
                Destroy(other.gameObject); // Destroy the player
                gameManager.GameOver();
            }
            else if (gameObject.CompareTag("Enemy")) // Check if the collided object is an enemy
            {
                Destroy(gameObject); // Destroy the enemy
                Destroy(other.gameObject); // Destroy the player
                gameManager.GameOver();
            }
        }
    }
}