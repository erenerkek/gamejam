using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerStats playerStats;

    public void TakeDamage(int amount)
    {
        playerStats.maxHealth -= amount; // Hasar alıyoruz

        if (playerStats.maxHealth <= 0)
        {
            Die();  // Ölünce seçim ekranı açılacak
        }
    }

    void Die()
    {
        // Seçim ekranı burada devreye girecek
        Debug.Log("Player died!");
        Destroy(gameObject); // Oyuncu nesnesini yok et
        // Burada GUI'yi tetikleyebilirsin.
    }
}
