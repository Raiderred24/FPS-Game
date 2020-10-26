using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    [SerializeField] GameObject PauseMenu = null;
    static public bool isPaused = false;
    int _currentScore;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu();
        }
    }
    public void IncreaseScore(int scoreIncrease)
    {
        // Increase score
        _currentScore += scoreIncrease;
        // Update score display to new score
       _currentScoreTextView.text =
            "Current Score: " + _currentScore.ToString();
    }
    public void ExitLevel()
    {
        // Compare scores
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (_currentScore > highScore)
        {
            // Save current score as new high score
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New high score: " + _currentScore);
        }
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }
    public void pauseMenu()
    {
        if (PauseMenu != null)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            PauseMenu.SetActive(isPaused);
        }
    }
}
