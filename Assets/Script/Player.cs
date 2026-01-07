using UnityEngine;
using UnityEngine.InputSystem;   // <-- penting

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
        float directionY = 0;

        if (Keyboard.current.wKey.isPressed)
            directionY = 1;
        else if (Keyboard.current.sKey.isPressed)
            directionY = -1;

        playerDirection = new Vector2(0, directionY).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, playerDirection.y * playerSpeed);

    }
}
