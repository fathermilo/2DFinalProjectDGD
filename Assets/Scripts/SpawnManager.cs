using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemyPrefab;
    private float spawnRange = 10.0f;
    public int enemyCount;
    public int waveNumber = 1;
    
    


    // Start is called before the first frame update
    void Start()
    {
        // spawns the enemy
        SpawnEnemyWave(waveNumber);
       
       
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            

        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        // Randomized the enemy's spawnpoint in the game
        float spawnPosY = Random.Range(8, spawnRange);
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int enemyIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[enemyIndex], GenerateSpawnPosition(), enemyPrefab[enemyIndex].transform.rotation);
        }

    }

    

}
