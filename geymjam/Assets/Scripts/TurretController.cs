using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
  public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float bulletSpeed = 20f;

    private float fireCooldown = 0f;
    private bool playerInRange = false;
    private Transform player;

    void Update()
    {
        if (playerInRange && player != null)
        {
            if (fireCooldown <= 0f)
            {
                Fire();
                fireCooldown = 1f / fireRate;
            }
            fireCooldown -= Time.deltaTime;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Vector2 direction = (player.position - firePoint.position).normalized;
        direction.y = 0f; // sadece yatay
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;
        }
    }
}