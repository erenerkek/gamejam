using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{

    public float moveSpeed = 5f;

    void Update()
    {
   
    }

    void FixedUpdate()
    {
             float moveX = Input.GetAxisRaw("Horizontal"); // A/D veya ←/→
        float moveY = Input.GetAxisRaw("Vertical");   // W/S veya ↑/↓

        Vector3 movement = new Vector3(moveX, moveY, 0f);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
