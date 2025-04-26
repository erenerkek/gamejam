using System.Collections;
using UnityEngine;

public class CyborgBossController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject gun;
    public GameObject shield;
    public float fireRate = 1f;
    public float phaseDuration = 5f; // 5 saniye ateþ / 5 saniye kalkan
    private bool isFiring = true;
    private float nextFireTime = 0f;

    public GameObject flamePrefab;  // Alev prefabý
    public Transform flamePoint1;   // Ýlk alev çýkacaðý yer
    public Transform flamePoint2;   // Ýkinci alev çýkacaðý yer

    private GameObject flameInstance1;
    private GameObject flameInstance2;


    void Start()
    {
        gun.SetActive(false);   // Baþta silah gizli
        shield.SetActive(false); // Baþta kalkan gizli
        StartCoroutine(BossBehaviorLoop());
    }

    void Update()
    {
        if (isFiring)
        {
            if (Time.time >= nextFireTime)
            {
                Fire();
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    IEnumerator BossBehaviorLoop()
    {
        while (true)
        {
            // Ateþ Etme Fazý
            isFiring = true;
            gun.SetActive(true);
            shield.SetActive(false);

            // Alevleri kapat
            if (flameInstance1 != null) Destroy(flameInstance1);
            if (flameInstance2 != null) Destroy(flameInstance2);

            yield return new WaitForSeconds(phaseDuration);

            // Kalkan Fazý
            isFiring = false;
            gun.SetActive(false);
            shield.SetActive(true);

            // Alevleri oluþtur
            flameInstance1 = Instantiate(flamePrefab, flamePoint1.position, flamePoint1.rotation);
            flameInstance2 = Instantiate(flamePrefab, flamePoint2.position, flamePoint2.rotation);

            // Alevlere BossFireDamage scripti ekle
            AddFireDamageComponent(flameInstance1);
            AddFireDamageComponent(flameInstance2);

            yield return new WaitForSeconds(phaseDuration);
        }
    }

    void Fire()
    {
        // Rastgele FirePoint seç
        Transform selectedFirePoint = (Random.value < 0.5f) ? firePoint1 : firePoint2;

        // Mermiyi oluþtur
        GameObject bulletGO = Instantiate(bulletPrefab, selectedFirePoint.position, selectedFirePoint.rotation);

        // Bullet scriptine eriþ
        EnemyBullet bulletScript = bulletGO.GetComponent<EnemyBullet>();

        // Yönü ayarla: (sola ateþ etmek için)
        bulletScript.shootDirection = Vector2.left;
    }

    // BossFireDamage scriptini alevlere ekle
    void AddFireDamageComponent(GameObject flame)
    {
        if (flame != null && flame.GetComponent<Collider2D>() != null)
        {
            BossFireDamage fireDamageScript = flame.AddComponent<BossFireDamage>();
            fireDamageScript.damage = 20;  // Ýstediðiniz hasarý buraya yazýn
        }
    }
}
