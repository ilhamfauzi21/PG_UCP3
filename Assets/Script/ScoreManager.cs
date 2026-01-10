using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // UI TextMeshPro untuk menampilkan skor
    public TextMeshProUGUI scoreText;
    private int score = 0; // Menyimpan nilai skor
    private bool isGameOver = false; // Status game over

    void Update()
    {
        // Perbarui tampilan skor setiap frame
        if (isGameOver) return;

        // Tambah skor setiap detik
        score += 1;
        scoreText.text = score.ToString(); // Tampilkan skor di UI
    }

    public int GetScore()
    {
        return score; // Mengembalikan nilai skor saat ini
    }

    public void StopScore()
    {
        isGameOver = true; // Hentikan penambahan skor saat game over
    }
}
