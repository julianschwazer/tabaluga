using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    
    public string left, right;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Mouse Position
        Vector3 mousePosition = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 0.25f, Camera.main.ScreenToWorldPoint (Input.mousePosition).z);
        Debug.Log(mousePosition.x + " , " + mousePosition.z);
    }

    private void FixedUpdate()
    {
        // Player Movement Centralised
        if (Input.GetKey(left))
        {
            //transform.Translate(new Vector3(-speed * Time.deltaTime, 0 , 0));
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self);
        }
        else if (Input.GetKey(right))
        {
            //transform.Translate(new Vector3(speed * Time.deltaTime, 0 , 0));
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
        }
    }
    
    
}
