using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pointA;
    public GameObject pointB;
    public float speed = 2f;

    private Rigidbody2D rb;
    private Transform currentPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointA.transform;
    }

    // Update is called once per frame
    void Update()
    {
         // Hedefe doğru ilerle
        Vector2 direction = (currentPoint.position - transform.position).normalized;
        rb.velocity = direction * speed;

        // Hedefe ulaştı mı kontrol et
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.1f)
        {
            // Diğer noktaya geç
            if (currentPoint == pointA.transform)
                currentPoint = pointB.transform;
            else
                currentPoint = pointA.transform;
        }
    }
        
}

