using UnityEngine;
using System.Collections;
public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

         if (spriteRenderer != null)
        {
            StartCoroutine(DamageFlash());
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

     private IEnumerator DamageFlash()
    {
        spriteRenderer.color = Color.red; // Hasar alınca kırmızı yap
        yield return new WaitForSeconds(0.2f); // (İstersen enemy için 0.2 saniye yapalım, hızlıca parlasın)
        spriteRenderer.color = originalColor; // Eski renge geri dön
    }


    public virtual void Die()
    {
        Destroy(gameObject); // Düşmanı yok eder
    }
}

