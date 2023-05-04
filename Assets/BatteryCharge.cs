using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BatteryCharge : MonoBehaviour
{
    public Drone drone;

    public float chargeAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Drone"))
        {
            return;
        }

        var batteryFillAmount = chargeAmount + drone.battery > 100 ? 100 - drone.battery : chargeAmount;
        drone.battery += batteryFillAmount;
        drone.batteryFill.transform.localScale += new Vector3(batteryFillAmount / 100f, 0, 0);
        drone.batteryFill.transform.position += new Vector3(-(batteryFillAmount / .1f) * 0.00015f, 0, 0);
        
        Destroy(gameObject);
    }
}
