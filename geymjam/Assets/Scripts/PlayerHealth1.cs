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
        currentHealth -= amount; // Hasar al
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // Eğer sağlık sıfırlanırsa, öl
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Ölüm işlemleri burada yapılacak
        SceneManager.LoadScene("Hub"); // Hub sahnesine geri dönüyoruz
    }

    // Yeniden doğma fonksiyonu
    public void ResetHealth()
    {
        if (playerStats != null)
        {
            // Yeni en yüksek sağlık değeriyle yeniden doğ
            currentHealth = playerStats.highestHealthReached;
            Debug.Log("Player health reset to: " + currentHealth); // Yeni can değeri loglanacak
        }
    }
}
