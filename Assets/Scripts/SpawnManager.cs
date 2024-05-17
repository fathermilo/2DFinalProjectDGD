using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab; // Prefab of the enemy
    public Transform spawnPoint; // Spawn point for the enemies
    public float spawnInterval = 2f; // Interval between enemy spawns
    public float distanceBetweenEnemies = 1.5f; // Distance between each enemy in the group
    public float despawnDelay = 5f; // Delay before despawning enemies

    private float spawnRangeX = 15;
    private float spawnPosZ = 15;

    public int currentWave = 1; // Track the current wave number
    public int enemyCount;

    void Start()
    {

        SpawnEnemyWave(currentWave);
        // Start spawning enemies
        InvokeRepeating("SpawnEnemyWave", 0f, spawnInterval);
    }

    void Update()
    {
        // Find all GameObjects with the Enemy component and count them
        enemyCount = FindObjectsOfType<EnemyMovement>().Length;
        // Check if there are no enemies remaining in the scene
        // Increment the wave number since all enemies have been defeated
        // Spawn a new wave of enemies based on the updated wave number
        // Spawn different prefabs
        if (enemyCount == 0)
        {
            currentWave++;
            SpawnEnemyWave(currentWave);


        }


    }

    void SpawnEnemyWave(int numberOfEnemies)
    {
        // Calculate the number of enemies for the current wave (starts with 1 for the first wave)


        // Calculate the starting position for the group of enemies
        Vector3 startPosition = spawnPoint.position - new Vector3((numberOfEnemies - 1) * distanceBetweenEnemies / 2f, 0f, 0f);

        // Spawn each enemy in the wave
        for (int i = 0; i < numberOfEnemies; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefab.Length);
            Vector3 spawnPosition = startPosition + new Vector3(i * distanceBetweenEnemies, 0f, 0f) + new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            GameObject enemy = Instantiate(enemyPrefab[enemyIndex], spawnPosition, Quaternion.Euler(0f, 0f, +90f));
            Destroy(enemy, despawnDelay);
        }


    }
}