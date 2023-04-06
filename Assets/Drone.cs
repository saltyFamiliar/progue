using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = System.Object;

public class Drone : MonoBehaviour
{
    private Rigidbody2D _rb;
    private string currentInstructions;

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

    [Header("Programming Interface")] 
    public InputField instructionInputField;
    public InputField outputConsole;
    
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

    private void UpdateConsole(string newText)
    {
        const int maxLines = 7;
        var oldLines = outputConsole.text.Split("\n");
        var newLines = newText.Split("\n");
        
        if (newLines.Length > 3)
        {
            newLines = new[] {newLines[0], newLines[1], "...",  newLines[^1]};
        }

        var totalLines = oldLines.Length + newLines.Length;
        if (totalLines > maxLines)
        {
            oldLines = oldLines.Skip(totalLines - maxLines).ToArray();
        }

        outputConsole.text = string.Join("\n", oldLines.Concat(newLines).ToArray());
    }


    public void InstallInstructions()
    {
        currentInstructions = instructionInputField.text;
        UpdateConsole("New instructions installed:\n" + currentInstructions);
        Debug.Log("New instructions installed:\n" + currentInstructions);
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
            if (battery <= 0)
            {
                return;
            }
            
            _rb.AddForce(Angler.AngleVector(transform) 
                         * (thrust * Time.deltaTime));
            
            battery -= 0.1f;
            batteryFill.transform.localScale += new Vector3(-0.001f, 0, 0);
            batteryFill.transform.position += new Vector3(0.00015f, 0, 0);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
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
