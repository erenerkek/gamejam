using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 20;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    public Vector2 shootDirection = Vector2.left;  // Merminin gideceði yön

    void Start()
    {
        rb.velocity = shootDirection * speed;  // shootDirection'a göre hýz ayarla
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

        if (impactEffect != null)
        {
            GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(impact, 0.5f);
        }

        Destroy(gameObject);
    }
}
