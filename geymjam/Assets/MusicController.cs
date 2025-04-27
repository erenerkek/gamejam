using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
private static MusicController instance;

    void Awake()
    {
        // Eğer instance daha önce oluşturulmuşsa, bu objeyi yok et
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Bu objeyi sahne değişimlerinde yok etme
        }
    }
}
