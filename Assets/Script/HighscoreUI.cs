using UnityEngine;
using TMPro;
using System.Text;

public class HighscoreUI : MonoBehaviour
{
    public HighscoreManager manager;
    public TextMeshProUGUI highscoreText;

    public void ShowHighscore()
    {
        var list = manager.GetHighscores();

        if (list.Count == 0)
        {
            highscoreText.text = "Belum ada highscore";
            return;
        }

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("HIGHSCORE");

        for (int i = 0; i < list.Count; i++)
        {
            sb.AppendLine($"{i + 1}. {list[i].playerName} - {list[i].score}");
        }

        highscoreText.text = sb.ToString();
    }
}
