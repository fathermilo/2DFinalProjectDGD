using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // variables for reference
    public Text scoreText;
    public Text highscoreText;
    public static int scoreCount;
    public static int highscoreCount;
    // Start is called before the first frame update
    void Start()
    {
        // If the "HighScore" key exists, retrieve the stored high score value and assign it to the highscoreCount variable
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscoreCount = PlayerPrefs.GetInt("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the current score is higher than the stored high score
        // Update the high score with the current score
        // Store the updated high score in PlayerPrefs
        if (scoreCount > highscoreCount)
        {
            highscoreCount = scoreCount;
            PlayerPrefs.SetInt("HighScore", highscoreCount);
        }

        // Update the score and highscore text UI with the current score
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highscoreText.text = "High Score: " + highscoreCount;
    }
}
