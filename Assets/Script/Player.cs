using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float playerSpeed = 5f;

    // 🔊 Audio
    public AudioClip moveSound;
    public AudioClip hitSound;

    private AudioSource moveAudio;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    private bool isGameOver = false;
    private bool canTrigger = false; // ⛔ kunci trigger di awal

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAudio = GetComponent<AudioSource>();

        // Buka trigger setelah physics stabil
        Invoke(nameof(EnableTrigger), 0.3f);
    }

    void EnableTrigger()
    {
        canTrigger = true;
    }

    void Update()
    {
        if (isGameOver) return;

        float directionY = 0;

        if (Keyboard.current.wKey.isPressed)
            directionY = 1;
        else if (Keyboard.current.sKey.isPressed)
            directionY = -1;

        playerDirection = new Vector2(0, directionY);

        // 🔊 sound gerak (sekali tekan)
        if (Keyboard.current.wKey.wasPressedThisFrame ||
            Keyboard.current.sKey.wasPressedThisFrame)
        {
            if (moveSound != null)
                moveAudio.PlayOneShot(moveSound);
        }
    }

    void FixedUpdate()
    {
        if (isGameOver)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = new Vector2(0, playerDirection.y * playerSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ⛔ BLOK TOTAL SAAT AWAL GAME
        if (!canTrigger || isGameOver) return;

        if (other.CompareTag("Obstacle"))
        {
            isGameOver = true;

            // 🔊 crash sound (PASTI hanya saat nabrak)
            if (hitSound != null && Camera.main != null)
            {
                AudioSource.PlayClipAtPoint(
                    hitSound,
                    Camera.main.transform.position,
                    1f
                );
            }

            rb.linearVelocity = Vector2.zero;

            FindFirstObjectByType<GameOver>().ShowGameOver();

            // sembunyikan player
            SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
            if (sr) sr.enabled = false;

            Collider2D col = GetComponent<Collider2D>();
            if (col) col.enabled = false;
        }
    }
}
