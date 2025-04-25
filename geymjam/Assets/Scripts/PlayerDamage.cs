using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerDamage : MonoBehaviour
{

    [SerializeField] private float damage;

private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        PlayerController controller = collision.gameObject.GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.TakeDamage(20);
        }
    }
}



}
