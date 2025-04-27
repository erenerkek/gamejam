using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli

public class PlayerHealth : MonoBehaviour
{
    private int currentHealth;
    private PlayerStats playerStats;  // PlayerStats referansı

    void Start()
    {
        // PlayerStats'i bul ve maxHealth'i al
        playerStats = GetComponent<PlayerStats>();
        
        if (playerStats != null)
        {
            currentHealth = playerStats.maxHealth;  // maxHealth'i PlayerStats'tan al
        }
        else
        {
            Debug.LogError("PlayerStats script not found on Player!");
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Burada istersen ölüm animasyonu, sahne reset gibi şeyler yapabilirsin
        Destroy(gameObject); // Şu anlık ölünce kendimizi yok ediyoruz
        SceneManager.LoadScene("Hub");
    }

    // Yeniden doğma fonksiyonu
    public void ResetHealth()
    {
        if (playerStats != null)
        {
            currentHealth = playerStats.maxHealth;  // Max canı PlayerStats'tan al
        }
    }
}
