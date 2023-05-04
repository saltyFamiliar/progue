using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Drone drone;

    private Rigidbody2D droneRB;
    private void Start()
    {
        droneRB = drone.gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float distance = Vector3.Distance(drone.gameObject.transform.position, gameObject.transform.position);
        if (distance <= 4)
        {
            var xDist = gameObject.transform.position.x - drone.gameObject.transform.position.x;
            var yDist = gameObject.transform.position.y - drone.transform.position.y;
            droneRB.AddForce(
                new Vector2(
                    xDist > .5 ? Math.Min(30/(xDist), 30f) : 0, 
                    yDist > .5 ? Math.Min(30/(yDist), 30f) : 0) 
                * Time.deltaTime);
                //drone.gameObject.transform.position += new Vector3(.1f, .1f, 0);
        }
        // _rb.AddForce(Angler.AngleVector(transform) 
        //              * (thrust * Time.deltaTime));
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (drone.battery <= 0)
        {
            return;
        }
        drone.battery -= 1f;
        drone.batteryFill.transform.localScale += new Vector3(-0.01f, 0, 0);
        drone.batteryFill.transform.position += new Vector3(0.0015f, 0, 0);
    }
}