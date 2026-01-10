using UnityEngine;                    // Library utama Unity
using UnityEngine.SceneManagement;    // Untuk pindah scene
using TMPro;                          // Untuk TextMeshPro (UI teks modern)
using System.IO;                      // Untuk operasi file (save/load JSON)

public class MenuManager : MonoBehaviour
{
    // Input field untuk memasukkan nama player
    public TMP_InputField nameInput;

    // Text untuk menampilkan nama player di UI
    public TextMeshProUGUI nameDisplay;

    // Path lokasi file save JSON
    private string filePath;

    void Start()
    {
        // Menentukan lokasi file save di folder persistentDataPath
        filePath = Application.persistentDataPath + "/playerData.json";

        // Reset input nama setiap menu dibuka
        nameInput.text = "";

        // Reset tampilan nama
        nameDisplay.text = "Nama: -";
    }

    // ================= SAVE =================
    public void SaveName()
    {
        // Cek jika input nama kosong
        if (string.IsNullOrEmpty(nameInput.text))
        {
            // Tampilkan peringatan di UI
            nameDisplay.text = "Nama: belum diisi";
            return;
        }

        // Membuat objek PlayerData untuk disimpan
        PlayerData data = new PlayerData
        {
            playerName = nameInput.text,   // Simpan nama player
            score = 0                      // Score awal = 0
        };

        // Mengubah data menjadi format JSON
        string json = JsonUtility.ToJson(data, true);

        // Menyimpan file JSON ke storage
        File.WriteAllText(filePath, json);

        // 🔥 Simpan nama player ke PlayerPrefs
        // Digunakan saat gameplay & high score
        PlayerPrefs.SetString("PLAYER_NAME", data.playerName);
        PlayerPrefs.Save();

        // Tampilkan nama yang berhasil disimpan
        nameDisplay.text = "Nama: " + data.playerName;
    }

    // ================= LOAD =================
    public void LoadName()
    {
        // Cek apakah file save belum ada
        if (!File.Exists(filePath))
        {
            // Tampilkan info jika data belum pernah disimpan
            nameDisplay.text = "Nama: belum ada";
            return;
        }

        // Membaca isi file JSON
        string json = File.ReadAllText(filePath);

        // Mengubah JSON menjadi object PlayerData
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);

        // Menampilkan nama ke input field
        nameInput.text = data.playerName;

        // Menampilkan nama ke UI text
        nameDisplay.text = "Nama: " + data.playerName;

        // 🔥 Sinkronkan kembali ke PlayerPrefs
        PlayerPrefs.SetString("PLAYER_NAME", data.playerName);
        PlayerPrefs.Save();
    }

    // ================= PLAY =================
    public void PlayGame()
    {
        // Cek apakah data player belum disimpan
        if (!File.Exists(filePath))
        {
            // Minta player isi dan save nama dulu
            nameDisplay.text = "Nama: isi & save dulu";
            return;
        }

        // Mencari AudioSource (musik menu)
        AudioSource menuMusic = FindObjectOfType<AudioSource>();

        // Jika musik ditemukan, hentikan musik
        if (menuMusic != null)
            menuMusic.Stop();

        // Pindah ke scene PlayGame
        SceneManager.LoadScene("PlayGame");
    }
}
