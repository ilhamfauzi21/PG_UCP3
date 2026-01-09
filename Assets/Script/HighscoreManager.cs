using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class HighscoreManager : MonoBehaviour
{
    private string filePath;
    public List<HighscoreData> highscores = new List<HighscoreData>();

    private const int MAX_HIGHSCORE = 5;

    void Awake()
    {
        filePath = Application.persistentDataPath + "/highscore.json";
        LoadHighscore();
    }

    // ================= SAVE =================
    public void SaveHighscore(string playerName, int score)
    {
        highscores.Add(new HighscoreData
        {
            playerName = playerName,
            score = score
        });

        // 🔥 Urutkan dari skor terbesar
        highscores = highscores
            .OrderByDescending(h => h.score)
            .Take(MAX_HIGHSCORE) // 🔥 AMBIL TOP 5 SAJA
            .ToList();

        SaveToFile();
    }

    // ================= GET =================
    public List<HighscoreData> GetHighscores()
    {
        return highscores;
    }

    // ================= FILE =================
    void SaveToFile()
    {
        string json = JsonUtility.ToJson(new Wrapper { list = highscores }, true);
        File.WriteAllText(filePath, json);
    }

    void LoadHighscore()
    {
        if (!File.Exists(filePath)) return;

        string json = File.ReadAllText(filePath);
        Wrapper wrapper = JsonUtility.FromJson<Wrapper>(json);
        highscores = wrapper.list ?? new List<HighscoreData>();
    }

    [System.Serializable]
    private class Wrapper
    {
        public List<HighscoreData> list;
    }
}
