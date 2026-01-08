using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float playerSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Keyboard input (W/S atau Up/Down)
        float directionY = Keyboard.current.wKey.isPressed ? 1 :
                           Keyboard.current.sKey.isPressed ? -1 : 0;

        playerDirection = new Vector2(0, directionY);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, playerDirection.y * playerSpeed);
    }
}
