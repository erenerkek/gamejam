using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public PlayerStats playerStats; // Oyuncunun istatistiklerini alır
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float fireCooldown => playerStats.fireCooldown ; // Ka� saniyede 1 kere ate� edebilir
    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bulletScript = bullet.GetComponent<Bullet>();

        // Player sa�a m� bak�yor sola m� kontrol et
        float direction = transform.localScale.x > 0 ? 1f : -1f;

        bulletScript.shootDirection = new Vector2(direction, 0f);
    }

}
