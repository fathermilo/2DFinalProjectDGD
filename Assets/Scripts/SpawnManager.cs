using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab of the enemy
    public Transform spawnPoint; // Spawn point for the enemies
    public float spawnInterval = 2f; // Interval between enemy spawns
    public int numberOfEnemiesInGroup = 5; // Number of enemies to spawn in each group
    public float distanceBetweenEnemies = 1.5f; // Distance between each enemy in the group
    public float despawnDelay = 5f; // Delay before despawning enemies

    void Start()
    {
        // Start spawning enemies
        InvokeRepeating("SpawnEnemyGroup", spawnInterval, spawnInterval);
    }

    void SpawnEnemyGroup()
    {
        // Calculate random offsets for the entire group along the X and Y axes
        float randomXOffset = Random.Range(-2f, 2f); // Adjust the range as needed
        float randomYOffset = Random.Range(-2f, 2f); // Adjust the range as needed

        // Calculate the starting position for the group of enemies
        Vector3 startPosition = spawnPoint.position - new Vector3((numberOfEnemiesInGroup - 1) * distanceBetweenEnemies / 2f, 0f, 0f);

        // Spawn each enemy in the group
        for (int i = 0; i < numberOfEnemiesInGroup; i++)
        {
            Vector3 spawnPosition = startPosition + new Vector3(i * distanceBetweenEnemies, 0f, 0f) + new Vector3(randomXOffset, randomYOffset, 0f);
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 90f));
            Destroy(enemy, despawnDelay);
        }
    }
}

