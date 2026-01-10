using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float playerSpeed = 5f; // Kecepatan player

    // Audio
    public AudioClip moveSound; // Suara saat bergerak
    public AudioClip hitSound;  // Suara saat game over

    private AudioSource moveAudio; // AudioSource player
    private Rigidbody2D rb;        // Rigidbody2D player
    private Vector2 playerDirection; // Arah gerak player
    private bool isGameOver = false; // Status game over

    void Start()
    {
        // Ambil komponen penting
        rb = GetComponent<Rigidbody2D>();
        moveAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Hentikan input jika game over
        if (isGameOver) return;

        float directionY = 0;

        // Input keyboard W / S
        if (Keyboard.current.wKey.isPressed)
            directionY = 1;
        else if (Keyboard.current.sKey.isPressed)
            directionY = -1;

        playerDirection = new Vector2(0, directionY);

        // Mainkan suara saat tombol ditekan
        if (Keyboard.current.wKey.wasPressedThisFrame ||
            Keyboard.current.sKey.wasPressedThisFrame)
        {
            moveAudio.PlayOneShot(moveSound);
        }
    }

    void FixedUpdate()
    {
        // Hentikan gerak saat game over
        if (isGameOver)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        // Gerakkan player secara vertikal
        rb.linearVelocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Jika menabrak obstacle
        if (other.CompareTag("Obstacle") && !isGameOver)
        {
            isGameOver = true;

            // Mainkan suara game over
            AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position, 1f);

            // Hentikan player
            rb.linearVelocity = Vector2.zero;

            // Tampilkan UI Game Over
            FindFirstObjectByType<GameOver>().ShowGameOver();

            // Sembunyikan player
            if (GetComponentInChildren<SpriteRenderer>())
                GetComponentInChildren<SpriteRenderer>().enabled = false;

            if (GetComponent<Collider2D>())
                GetComponent<Collider2D>().enabled = false;
        }
    }
}
