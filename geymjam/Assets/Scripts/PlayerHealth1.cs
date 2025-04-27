using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class PlayerHealth : MonoBehaviour
{
    private int currentHealth;
    private PlayerStats playerStats;
    private SpriteRenderer spriteRenderer; 
    private Color originalColor;


    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer'ı bul
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color; // Orijinal rengi kaydet
        }

        if (playerStats != null)
        {
            currentHealth = playerStats.maxHealth;
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
        
         if (spriteRenderer != null)
        {
            StartCoroutine(DamageFlash()); // Hasar aldığında renk değiştir
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator DamageFlash()
    {
        spriteRenderer.color = Color.red; // Kırmızı yapabilirsin veya Color.white (beyaz) da olur
        yield return new WaitForSeconds(0.5f); // 0.5 saniye bekle
        spriteRenderer.color = originalColor; // Eski renge geri dön
    }

    void Die()
    {
        Debug.Log("Player died!");
        SceneManager.LoadScene("Hub");
    }

    public void ResetHealth()
    {
        if (playerStats != null)
    {
        playerStats.LoadStats(); // 🔥 PlayerPrefs'ten güncel değerleri çek
        currentHealth = playerStats.maxHealth; // 🔥 Güncel maxHealth'ten canı doldur
    }
    }

}
