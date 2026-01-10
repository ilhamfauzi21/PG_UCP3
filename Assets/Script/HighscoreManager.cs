using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class HighscoreManager : MonoBehaviour
{
    private string filePath;   // Lokasi file highscore.json
    public List<HighscoreData> highscores = new List<HighscoreData>(); // List data highscore

    private const int MAX_HIGHSCORE = 5; // Batas jumlah highscore (Top 5)

    void Awake()
    {
        // Tentukan path penyimpanan & load data saat game mulai
        filePath = Application.persistentDataPath + "/highscore.json";
        LoadHighscore();
    }

    // ================= SAVE =================
    public void SaveHighscore(string playerName, int score)
    {
        // Tambahkan data score baru
        highscores.Add(new HighscoreData
        {
            playerName = playerName,
            score = score
        });

        // Urutkan skor dari terbesar dan ambil Top 5
        highscores = highscores
            .OrderByDescending(h => h.score)
            .Take(MAX_HIGHSCORE)
            .ToList();

        // Simpan ke file
        SaveToFile();
    }

    // ================= GET =================
    public List<HighscoreData> GetHighscores()
    {
        // Mengembalikan list highscore (untuk UI)
        return highscores;
    }

    // ================= FILE =================
    void SaveToFile()
    {
        // Simpan list highscore ke file JSON
        string json = JsonUtility.ToJson(new Wrapper { list = highscores }, true);
        File.WriteAllText(filePath, json);
    }

    void LoadHighscore()
    {
        // Load data highscore dari file jika ada
        if (!File.Exists(filePath)) return;

        string json = File.ReadAllText(filePath);
        Wrapper wrapper = JsonUtility.FromJson<Wrapper>(json);
        highscores = wrapper.list ?? new List<HighscoreData>();
    }

    [System.Serializable]
    private class Wrapper
    {
        // Pembungkus list agar bisa diserialisasi JSON
        public List<HighscoreData> list;
    }
}
