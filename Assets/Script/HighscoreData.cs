using System;   // Digunakan untuk atribut [Serializable]

[Serializable]  // Menandai class agar bisa disimpan / dibaca sebagai data (JSON, PlayerPrefs, dll)
public class HighscoreData
{
    // Menyimpan nama pemain
    public string playerName;

    // Menyimpan nilai skor pemain
    public int score;
}
