using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float fireCooldown = 1f; // Başlangıç fireCooldown
    private float nextFireTime = 0f;

    private PlayerStats playerStats;  // PlayerStats referansı

    void Start()
    {
        // Player objesini bulup PlayerStats bileşenine erişiyoruz
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

        if (playerStats != null)
        {
            fireCooldown = playerStats.attackCooldown;  // PlayerStats'tan fireCooldown alıyoruz
        }
        else
        {
            Debug.LogError("PlayerStats bileşeni bulunamadı!");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown; // fireCooldown'e göre atış yapıyoruz
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        // Player sağa mı bakıyor sola mı kontrol et
        float direction = transform.localScale.x > 0 ? 1f : -1f;

        bulletScript.shootDirection = new Vector2(direction, 0f);
    }
}
