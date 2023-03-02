using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Rigidbody2D _rb;

    [Header("Movement")] 
    public float forceMultiplier = 1;
    public float speed = 3f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void FixedUpdate()
    {
        _rb.AddForce(
            new Vector2(
                Input.GetAxisRaw("Horizontal"), 
                Input.GetAxisRaw("Vertical")) 
            * (forceMultiplier * speed));

    }
}
