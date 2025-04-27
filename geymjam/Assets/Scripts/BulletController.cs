using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
  public int damage = 20; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Mermi oyuncuya çarptı, hasar alındı!");

            Destroy(gameObject);
        }
        else if (!collision.isTrigger) 
        {
            Destroy(gameObject);
        }
    }
}