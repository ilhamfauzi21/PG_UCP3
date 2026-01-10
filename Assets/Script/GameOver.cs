using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;        // Panel UI Game Over
    public ScoreManager scoreManager;       // Mengelola skor
    public HighscoreManager highscoreManager; // Mengelola data highscore
    public HighscoreUI highscoreUI;         // Menampilkan highscore ke UI

    void Start()
    {
        // Sembunyikan panel Game Over saat game dimulai
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        // Hentikan perhitungan skor
        scoreManager.StopScore();

        // Pause game
        Time.timeScale = 0f;

        // Ambil skor akhir dan nama player
        int finalScore = scoreManager.GetScore();
        string playerName = PlayerPrefs.GetString("PLAYER_NAME", "Unknown");

        // Simpan dan tampilkan highscore
        highscoreManager.SaveHighscore(playerName, finalScore);
        highscoreUI.ShowHighscore();

        // Tampilkan panel Game Over
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        // Jalankan kembali game
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
