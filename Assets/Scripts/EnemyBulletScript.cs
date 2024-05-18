using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;
    private GameManager gameManager; // Reference to the GameManager
    private bool playerExists; // Check if player still exists

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Find the player initially
        player = GameObject.FindGameObjectWithTag("Player");
        playerExists = player != null;

        // If the player exists, shoot towards it
        if (playerExists)
        {
            ShootPlayer();
        }
    }

    void Update()
    {
        // Check if the player still exists
        if (!playerExists)
        {
            // If the player does not exist, destroy this bullet
            Destroy(gameObject);
            return;
        }

        // If the game is not active, destroy this bullet
        if (!gameManager.isGameActive)
        {
            Destroy(gameObject);
            return;
        }

        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManager.GameOver();
        }
    }

    void ShootPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = direction.normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);
    }
}
