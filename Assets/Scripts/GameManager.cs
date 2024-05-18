using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public Transform spawnPoint; // Spawn point for the enemies
    private float spawnRate = 2.0f;
    public GameObject[] powerupPrefab;

    private float spawnRange = 15;
    public bool isGameActive;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    private static int score;
    private static int highscoreCount;
    public Button restartButton;
    public GameObject titleScreen;
    public TextMeshProUGUI gameOverText;
    public GameObject powerupIndicator;

    void Start()
    {
        // Load the high score from player preferences if it exists
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscoreCount = PlayerPrefs.GetInt("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update the high score if the current score surpasses it
        if (score > highscoreCount)
        {
            highscoreCount = score;
            PlayerPrefs.SetInt("HighScore", highscoreCount);
        }


    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Vector3 spawnPosition = GenerateSpawnPosition();
            Quaternion spawnRotation = Quaternion.Euler(0, 0, 90); // Face downwards
            Instantiate(targets[index], spawnPosition, spawnRotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        // Randomize the enemy's spawn point in the game
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 13, 0);
        return randomPos;
    }

    

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnPowerUpsCoroutine());
        score = 0;
        UpdateScore(0);

    }
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        highscoreText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        isGameActive = false;
        powerupIndicator.SetActive(false);

    }

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator SpawnPowerUpsCoroutine()
    {
        while (isGameActive)
        {
            float spawnPosY = Random.Range(-spawnRange, spawnRange);
            float spawnPosX = Random.Range(-spawnRange, spawnRange);
            yield return new WaitForSeconds(3);
            int powerupIndex = Random.Range(0, powerupPrefab.Length);
            Instantiate(powerupPrefab[powerupIndex], new Vector3(spawnPosX, spawnPosY, 0), Quaternion.identity);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        highscoreText.text = "High Score: " + highscoreCount;
    }
}