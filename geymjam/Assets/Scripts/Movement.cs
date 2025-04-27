using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    public float moveSpeed = 10f;
    public float jumpForce = 16f;
    public float coyoteTime = 0.2f; // zıplama affı için

    [Header("Yer Kontrolü")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded;
    private float coyoteCounter;

    private float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Yatay giriş (A-D veya ok tuşları)
        horizontal = Input.GetAxisRaw("Horizontal");

        // Yüzünü döndür
        if (horizontal != 0)
            sr.flipX = horizontal < 0;

        // Yerde mi?
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Coyote Time (hafif geç zıplama toleransı)
        if (isGrounded)
            coyoteCounter = coyoteTime;
        else
            coyoteCounter -= Time.deltaTime;

        // Zıplama
        if (Input.GetButtonDown("Jump") && coyoteCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            coyoteCounter = 0f;
        }
    }

    void FixedUpdate()
    {
        // Hareket uygula
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
