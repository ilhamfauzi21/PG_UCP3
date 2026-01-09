using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameOver gameOver;

    void Start()
    {
        gameOver = FindFirstObjectByType<GameOver>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            gameOver.ShowGameOver();
            collision.gameObject.SetActive(false); // OPTIONAL
        }
    }
}
