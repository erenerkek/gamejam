using UnityEngine;

public class DroneShooter : MonoBehaviour
{
    public Transform firePoint;         // FirePoint'i burada tanımlıyoruz
    public GameObject laserPrefab;       // Lazer prefabını buraya atayacağız
    public float fireInterval = 2f;       // 5 saniyede bir ateşlesin
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireInterval)
        {
            ShootLaser();
            timer = 0f; // zamanı sıfırla
        }
    }

    void ShootLaser()
    {
        Instantiate(laserPrefab, firePoint.position, Quaternion.identity);
    }
}
