using UnityEngine;

public class BossHealth : EnemyHealth
{
    public override void Die()
    {
        // Boss öldüğünde statları arttır
        PlayerStats playerStats = FindObjectOfType<PlayerStats>(); // PlayerStats'i buluyoruz
        playerStats.IncreaseStatsAfterBossKill(); // Boss öldüğünde statları arttır

        PlayerPrefs.SetInt("listindex", PlayerPrefs.GetInt("listindex", 0) + 1);
        Destroy(gameObject); // Düşmanı yok eder
    }
}
