using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player/Stats")]
public class PlayerStats : ScriptableObject
{
    public int maxHealth = 100;     // Başlangıç canı
    public int damage = 10;         // Başlangıç hasarı
    public float fireCooldown = 1f;  // Başlangıç saldırı hızı


    public void IncreaseHealth(int amount)
    {
        maxHealth += amount;   // Can arttırma
    }

    public void IncreaseDamage(int amount)
    {
        damage += amount;      // Hasar arttırma
    }

    public void DecreaseFireCoolDown(float amount)
    {
        fireCooldown -= amount; // Saldırı hızı arttırma
    }
}
