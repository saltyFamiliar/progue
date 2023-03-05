using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = System.Object;

public class Drone : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Header("Movement")] 
    public float thrust = 100;
    public float turnSpeed = 2;
    public float ammo = 100;


    [Header("Resources")] 
    public float battery = 100;
    public GameObject batteryFill;
    public GameObject projectile;

    [Header("Combat")] 
    public GameObject turret;
    public float bulletForce;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0)
        {
            Shoot();
            ammo -= 1;
        }
    }

    private void Turn(Transform t, float units)
    {
        t.Rotate(0, 0, 45*units);
    }
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Turn(transform, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Turn(transform, -turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            Turn(turret.transform, turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            Turn(turret.transform, -turnSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _rb.AddForce(Angler.AngleVector(transform) 
                         * (thrust * Time.deltaTime));
            
            battery -= 0.1f;
            batteryFill.transform.localScale += new Vector3(-0.001f, 0, 0);
            batteryFill.transform.position += new Vector3(0.00015f, 0, 0);
        }

    }

    private void Shoot()
    {
        var p = transform.position;
        Instantiate(projectile, new Vector3(p.x, p.y), Quaternion.identity)
            .GetComponent<Rigidbody2D>()
            .AddForce(Angler.AngleVector(turret.transform) * bulletForce);
    }
}
