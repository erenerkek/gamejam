using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesController : MonoBehaviour
{
    // Start is called before the first frame update

    private static SesController instance;
    void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject); // Bu nesneyi sahneler arasında taşımak için
            }
            else
            {
                Destroy(gameObject); // Eğer başka bir örnek varsa, bu nesneyi yok et
            }
        }

}
