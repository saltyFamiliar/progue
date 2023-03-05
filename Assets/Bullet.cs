using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Properties")]
    public int lifetime = 1000;
    
    void Start()
    {

    }

    private void Awake()
    {
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        lifetime -= 1;
        if (lifetime == 0)
        {
            Destroy(gameObject);
        }
    }
}
