using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerScript : MonoBehaviour
{
    private Rigidbody _rb;
    
    public string left, right;
    public float speed;
    public float paddleX;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // change position of al paddles with the mouse
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get mouse position
        //mousePos = new Vector3(paddleX, 0, mousePos.z); // ignore unneeded coordinates
        //_rb.velocity = (mousePos - transform.position) * speed; // change paddle position with mouse
        
        // player login interface overlay
        // countdown 

        // Assign TSPS coordinates to player coordinates when the countdown hits zero
        // if playerOne --> centroidX = _playerOneX; centroidZ = _playerOneZ;
        // ...
        
        // Player 1
        // if X > 6 and Z < 0
        
        // Player 2
        // if X < 6 and Z > 0
        
        // Player 3
        // if X > -6 and Z < 0
        
        // Player 4
        // if X < -6 and Z > 0
        
        //Vector3 playerPos = new Vector3(centroidX, 0 centroidZ);
        //_rb.velocity = (playerPos - transform.position) * speed;
        
        
        ////////// ---------- CODE ARCHIVE ----------
        
        // Mouse Position
        //Vector3 mousePosition = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, 0.25f, Camera.main.ScreenToWorldPoint (Input.mousePosition).z);
        //Debug.Log(mousePosition.x + " , " + mousePosition.z);
        
        // Player Movement Centralised
        if (Input.GetKey(left) && transform.position.z > -3.4)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed, Space.Self);
        }
        else if (Input.GetKey(right) && transform.position.z < 3.4)
        {
            //transform.Translate(new Vector3(speed * Time.deltaTime, 0 , 0));
            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
        }   
    } 
}

