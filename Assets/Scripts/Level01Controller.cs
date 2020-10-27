using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text _currentScoreTextView;
    [SerializeField] GameObject PauseMenu = null;
    [SerializeField] Text HighScoreText;
    [SerializeField] Text ScoreText;
    static public bool isPaused = false;
    int _currentScore;
    private void Start()
    {
        _currentScoreTextView.text = "Current Score: " + _currentScore.ToString();
    }
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
    public void winGame()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (_currentScore > highScore || highScore == 0)
        {
            highScore = _currentScore;
            // Save current score as new high score
            PlayerPrefs.SetInt("HighScore", _currentScore);
            Debug.Log("New high score: " + _currentScore);
        }
        HighScoreText.text = "High Score: " + highScore;
        ScoreText.text = "Score: " + _currentScore;
    }
    public void increaseScore (int amount)
    {
        _currentScore += amount;
    }
}
