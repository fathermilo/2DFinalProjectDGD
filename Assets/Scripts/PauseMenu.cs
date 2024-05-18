using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // boolean to check if game is paused
    // game object pause menu UI text
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        // Check if the Escape key is pressed

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the game is already paused, resume it
            if (GameIsPaused)
            {
                GameResume();
                // If the game is not paused, pause it
            }
            else
            {
                GamePause();
            }
        }
    }
    // Deactivate the pause menu UI
    // Set the time scale to normal
    // boolean GameIsPaused is false
    void GameResume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
    // Activate the pause menu UI
    // Set the time scale to 0
    // boolean GameIsPaused is true
    void GamePause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
}
