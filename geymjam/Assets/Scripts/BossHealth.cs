using UnityEngine;

public class BossHealth : EnemyHealth
{

    public override void Die()
    {
        PlayerPrefs.SetInt("listindex", PlayerPrefs.GetInt("listindex",0) + 1);
        Destroy(gameObject); // Düşmanı yok eder
    }
}

