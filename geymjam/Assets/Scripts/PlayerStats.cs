using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentHealth;
    public int highestHealthReached = 100; // Başlangıç sağlık değeri
    public float attackCooldown = 1f; // Başlangıç attack cooldown (ateş etme hızı)
    public int damage = 10; // Başlangıç hasarı
    public int maxHealth = 100; // Yeni eklenen maxHealth

    // Bu değerleri respawn sırasında kullanacağız
    public void ResetStatsOnRespawn()
    {
        currentHealth = highestHealthReached; // Canı en yüksek sağlık değerine eşitle
    }

    // Boss öldüğünde statları geliştirme
    public void IncreaseStatsAfterBossKill()
    {
        // Örnek: Boss öldüğünde cooldown artıyor
        attackCooldown -= 0.2f; // Cooldown azalarak daha hızlı ateş etmesini sağlıyoruz

        if (attackCooldown < 0.2f) // Minimum cooldown'u belirliyoruz
        {
            attackCooldown = 0.2f; // Minimum cooldown 0.2 saniye
        }

        highestHealthReached += 20; // En yüksek sağlık artıyor
        maxHealth = highestHealthReached; // Max sağlık artık highestHealthReached ile eşit olacak

        damage += 5; // Attack damage artıyor
    }
}
