using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public ScoreManager scoreManager;
    public HighscoreManager highscoreManager;
    public HighscoreUI highscoreUI;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        // STOP SCORE
        scoreManager.StopScore();

        Time.timeScale = 0f;

        int finalScore = scoreManager.GetScore();
        string playerName = PlayerPrefs.GetString("PLAYER_NAME", "Unknown");

        highscoreManager.SaveHighscore(playerName, finalScore);
        highscoreUI.ShowHighscore();

        gameOverPanel.SetActive(true);
    }


    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
