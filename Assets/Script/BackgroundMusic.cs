using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic backgroundMusic;
    // Singleton: memastikan musik latar hanya satu

    void Awake()
    {
        // Jika belum ada musik latar
        if (backgroundMusic == null)
        {
            // Simpan instance dan jangan hancurkan saat pindah scene
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
        else
        {
            // Hapus duplikat musik
            Destroy(gameObject);
        }
    }
}
