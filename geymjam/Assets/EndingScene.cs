using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene : MonoBehaviour
{
    public GameObject Image;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Image.gameObject.SetActive(true);



        }
    }

    
}
