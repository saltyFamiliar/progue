using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static int lifetime = 200;
    

    private void FixedUpdate()
    {
        lifetime -= 1;
        if (lifetime == 0)
        {
            Destroy(gameObject);
        }
    }
    
    // private void OnCollisionEnter2D(Collision2D col)
    // {
    //         Destroy(gameObject);
    // }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Drone") || col.gameObject.CompareTag("Charge"))
        {
            return;
        }
        
        Destroy(gameObject);
        
        if (col.gameObject.CompareTag("Destructible"))
        {
            Destroy(col.gameObject);
        }
        
    }
}
