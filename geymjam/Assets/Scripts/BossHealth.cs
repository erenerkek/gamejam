using UnityEngine;

public class BossHealth : EnemyHealth
{
    public PlayerStats playerStats;  // PlayerStats referansı ekledik
    private int bossKillMultiplier = 1;  // İlk başta 1, her boss öldüğünde artacak

    public override void Die()
    {
        PlayerPrefs.SetInt("listindex", PlayerPrefs.GetInt("listindex", 0) + 1);

        // Boss öldüğünde, oyuncunun özelliklerini artır
        playerStats.IncreaseHealth(50 * bossKillMultiplier);   // Can artışı
        playerStats.IncreaseDamage(15 * bossKillMultiplier);   // Hasar artışı
        playerStats.DecreaseFireCoolDown(0.1f * bossKillMultiplier);  // Boss öldükçe bu azalma miktarı büyüyecek // Saldırı hızı artışı

        // Boss öldükçe, multiplier artacak
        bossKillMultiplier++;

        Destroy(gameObject); // Düşmanı yok eder
    }
}
