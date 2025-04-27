using UnityEngine;

public class Weapon : MonoBehaviour
{

    [Header("Ses Ayarları")]
    public AudioClip gunshotSound; // Inspector'dan ses dosyası atanacak
    private AudioSource audioSource; // Kodla otomatik eklenecek
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
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // Oyun başlangıcında çalmasın
        audioSource.volume = 0.8f; // Ses seviyesi (0-1 arası)
        DontDestroyOnLoad(gameObject);
    
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

        if (gunshotSound != null)
        {
            audioSource.PlayOneShot(gunshotSound);
        }
        else
        {
            Debug.LogWarning("Silah sesi atanmamış! Inspector'dan AudioClip ekle.");
        }

     

    }
}
