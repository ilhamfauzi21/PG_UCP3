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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAudio = GetComponent<AudioSource>();
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
        if (other.CompareTag("Obstacle") && !isGameOver)
        {
            isGameOver = true;

            // 🔊 GAME OVER SOUND (PASTI BUNYI)
            AudioSource.PlayClipAtPoint(
                hitSound,
                Camera.main.transform.position,
                1f
            );

            rb.linearVelocity = Vector2.zero;

            FindFirstObjectByType<GameOver>().ShowGameOver();

            // sembunyikan player (aman)
            if (GetComponentInChildren<SpriteRenderer>())
                GetComponentInChildren<SpriteRenderer>().enabled = false;

            if (GetComponent<Collider2D>())
                GetComponent<Collider2D>().enabled = false;
        }
    }
}
