using UnityEngine;
using TMPro;
using System.Text;

public class HighscoreUI : MonoBehaviour
{
    public HighscoreManager manager;      // Referensi ke HighscoreManager
    public TextMeshProUGUI highscoreText; // UI untuk menampilkan highscore

    public void ShowHighscore()
    {
        // Ambil list highscore dari manager
        var list = manager.GetHighscores();

        // Jika belum ada data highscore
        if (list.Count == 0)
        {
            highscoreText.text = "Belum ada highscore";
            return;
        }

        // StringBuilder untuk menyusun teks agar efisien
        StringBuilder sb = new StringBuilder();

        // Judul highscore
        sb.AppendLine("HIGHSCORE");

        // Loop menampilkan ranking (Top 5)
        for (int i = 0; i < list.Count; i++)
        {
            sb.AppendLine($"{i + 1}. {list[i].playerName} - {list[i].score}");
        }

        // Tampilkan ke UI TextMeshPro
        highscoreText.text = sb.ToString();
    }
}
