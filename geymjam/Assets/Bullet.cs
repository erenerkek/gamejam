using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
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
