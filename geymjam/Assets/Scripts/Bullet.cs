using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerStats playerStats;
    public float speed = 20f;

    public int damage => playerStats.damage; // Oyuncunun hasarını alır
    public Rigidbody2D rb;
    public GameObject impactEffect;

    public Vector2 shootDirection = Vector2.right; // default sağa

    void Start()
    {
        rb.velocity = shootDirection * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Düşmana çarparsa hasar ver
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
    
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        // Impact Effecti oluştur
        if (impactEffect != null)
        {
            GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(impact, 0.5f); // Efekti 0.5 saniyede yok et (istersen değiştirirsin)
        }

        // Mermiyi yok et
        Destroy(gameObject);
    }
}
