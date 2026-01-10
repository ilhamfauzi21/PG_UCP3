using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI nameDisplay;

    private string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/playerData.json";

        // Reset UI setiap menu dibuka
        nameInput.text = "";
        nameDisplay.text = "Nama: -";
    }

    // ================= SAVE =================
    public void SaveName()
    {
        if (string.IsNullOrEmpty(nameInput.text))
        {
            nameDisplay.text = "Nama: belum diisi";
            return;
        }

        PlayerData data = new PlayerData
        {
            playerName = nameInput.text,
            score = 0
        };

        // SIMPAN KE JSON
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);

        // 🔥 SIMPAN KE PLAYERPREFS (UNTUK GAMEPLAY & HIGHSCORE)
        PlayerPrefs.SetString("PLAYER_NAME", data.playerName);
        PlayerPrefs.Save();

        nameDisplay.text = "Nama: " + data.playerName;
    }


    // ================= LOAD =================
    public void LoadName()
    {
        if (!File.Exists(filePath))
        {
            nameDisplay.text = "Nama: belum ada";
            return;
        }

        string json = File.ReadAllText(filePath);
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);

        nameInput.text = data.playerName;
        nameDisplay.text = "Nama: " + data.playerName;

        // 🔥 SINKRON KE PLAYERPREFS
        PlayerPrefs.SetString("PLAYER_NAME", data.playerName);
        PlayerPrefs.Save();
    }


    // ================= PLAY =================
    public void PlayGame()
    {
        if (!File.Exists(filePath))
        {
            nameDisplay.text = "Nama: isi & save dulu";
            return;
        }

        // Hentikan musik menu
        AudioSource menuMusic = FindObjectOfType<AudioSource>();
        if (menuMusic != null)
            menuMusic.Stop();

        SceneManager.LoadScene("PlayGame");
    }
}