using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;
    public float attackCooldown = 1f;
    public int damage = 10;

    private void Awake()
    {
        LoadStats(); // Oyuncu doğduğunda kayıtlı değerleri oku
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void IncreaseStatsAfterBossKill()
    {
        maxHealth += 20;
        damage += 20;
        attackCooldown -= 0.2f;

        if (attackCooldown < 0.2f)
        {
            attackCooldown = 0.2f;
        }

        SaveStats(); // Boss öldürebilince değerleri kaydet
    }

    public void SaveStats()
    {
        PlayerPrefs.SetInt("MaxHealth", maxHealth);
        PlayerPrefs.SetInt("Damage", damage);
        PlayerPrefs.SetFloat("AttackCooldown", attackCooldown);
        PlayerPrefs.Save();
    }

    public void LoadStats()
    {
        if (PlayerPrefs.HasKey("MaxHealth"))
        {
            maxHealth = PlayerPrefs.GetInt("MaxHealth");
        }

        if (PlayerPrefs.HasKey("Damage"))
        {
            damage = PlayerPrefs.GetInt("Damage");
        }

        if (PlayerPrefs.HasKey("AttackCooldown"))
        {
            attackCooldown = PlayerPrefs.GetFloat("AttackCooldown");
        }

        currentHealth = maxHealth;
    }

    public void ResetStats()
    {
        // İstersen sıfırlama için
        PlayerPrefs.DeleteAll();
    }
}
