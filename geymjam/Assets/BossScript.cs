using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject firePrefab; // Platformlardaki küçük ateþ prefabý
    public GameObject groundFirePrefab; // Zemindeki büyük ateþ prefabý

    public Transform[] platformFirePoints; // 3 tane platform için FirePoint
    public Transform groundFirePoint; // Zemin için FirePoint

    public float switchTime = 5f;
    public int fireDamage = 20;

    private GameObject[] platformFires;
    private GameObject groundFire;
    private bool isPlatformFireActive = true;

    void Start()
    {
        platformFires = new GameObject[platformFirePoints.Length];
        InvokeRepeating(nameof(SwitchFire), 0f, switchTime);
    }

    void SwitchFire()
    {
        if (isPlatformFireActive)
        {
            // Platformlardaki ateþleri aktif et, zemindeki ateþi kapat
            if (groundFire != null)
            {
                Destroy(groundFire);
            }

            for (int i = 0; i < platformFirePoints.Length; i++)
            {
                platformFires[i] = Instantiate(firePrefab, platformFirePoints[i].position, platformFirePoints[i].rotation);
                AddDamageComponent(platformFires[i]);
            }
        }
        else
        {
            // Platformlardaki ateþleri kapat, zemindeki ateþi aktif et
            for (int i = 0; i < platformFires.Length; i++)
            {
                if (platformFires[i] != null)
                {
                    Destroy(platformFires[i]);
                }
            }

            groundFire = Instantiate(groundFirePrefab, groundFirePoint.position, groundFirePoint.rotation);
            AddDamageComponent(groundFire);
        }

        // Sýradakine geç
        isPlatformFireActive = !isPlatformFireActive;
    }

    void AddDamageComponent(GameObject fire)
    {
        var damageArea = fire.AddComponent<BossFireDamage>();
        damageArea.damage = fireDamage;
    }
}
