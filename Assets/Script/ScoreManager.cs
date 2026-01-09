using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        score += 1;
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void StopScore()
    {
        isGameOver = true;
    }
}
