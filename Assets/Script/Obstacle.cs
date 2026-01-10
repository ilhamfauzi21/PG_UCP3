using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player; // Referensi ke object Player

    // Dipanggil saat object pertama kali aktif
    void Start()
    {
        // Mencari Player berdasarkan tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Dipanggil saat terjadi tabrakan trigger 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jika obstacle menyentuh border (batas layar)
        if (collision.tag == "Border")
        {
            // Hancurkan obstacle
            Destroy(this.gameObject);
        }
        // Jika obstacle menabrak player
        else if (collision.tag == "Player")
        {
            // Hancurkan player (game over)
            Destroy(player.gameObject);
        }
    }
}
