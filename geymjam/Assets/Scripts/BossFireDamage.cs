using UnityEngine;

public class BossFireDamage : MonoBehaviour
{
    public int damage = 20;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
