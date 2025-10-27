using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D_Sharp : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;          // Movement speed (tune this to match your game feel)

    [Header("Facing")]
    public bool faceRightByDefault = true;

    private Rigidbody2D rb;
    private float moveInput;
    private bool facingRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;  // no gravity for fighter-style movement
        rb.freezeRotation = true;
        facingRight = faceRightByDefault;
    }

    void Update()
    {
        // Raw digital input (-1, 0, 1)
        moveInput = Input.GetAxisRaw("Horizontal");

        // Flip sprite when changing direction
        if (moveInput > 0 && !facingRight)
            Flip();
        else if (moveInput < 0 && facingRight)
            Flip();
    }

    void FixedUpdate()
    {
        // Instantly move at full speed or stop
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, 0f);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
