using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck; 
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Transform firePoint;



    bool isGrounded = false;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        animator.SetBool("IsGrounded", isGrounded);

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("IsJumping", true);
            isGrounded = false; // Yere basmadığını belirt
        }

        if (!isGrounded)
        {
            if (rb.velocity.y > 0.1f)
            {
                // Yukar� do�ru giderken Jump animasyonu
                animator.SetBool("IsJumping", true);
            }
            else if (rb.velocity.y <= 0)
            {
                // A�a�� d��meye ba�lad�ysa Fall tetikle
                animator.SetBool("IsJumping", false);
                animator.SetTrigger("IsFalling"); // Trigger'� burada her zaman set et
            }
        }
        else if (isGrounded && rb.velocity.y <= 0f)
        {
            // Yere indi�inde her �eyi s�f�rla
            animator.SetBool("IsJumping", false);
            animator.ResetTrigger("IsFalling");
        }

        Flip();
    }



    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

            if(localScale.x < 0f)
            {
                firePoint.localRotation = new Quaternion(0f, 0f, 0f, firePoint.rotation.w);
            }
            else
            {
                firePoint.localRotation = new Quaternion(0f, 180f, 0f, firePoint.rotation.w);
            }
        }
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
        }
    }
}
