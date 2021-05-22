using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private Rigidbody rb;
    
    public string left, right;
    public float speed;


    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        //Movement();

            // Mouse Position
            Vector3 mousePosition = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, Camera.main.ScreenToWorldPoint (Input.mousePosition).z);
            float input = Input.mousePosition.x;
        //GetComponent<Rigidbody>().transform.Translate = new Vector3(input, 0);

             GetComponent<Rigidbody>().transform.position = Input.mousePosition;
           //rb.transform.position = input.x;
             Debug.Log(mousePosition.x + " , " + mousePosition.y + " , " + mousePosition.z);

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

    private void OnCollisionStay(Collision collision)
    {
        
    }

   /* void Movement()
    {
        if (transform.position.x < -5 && transform.position.x > -6.8)
        {

        
            // Mouse Position
            Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0.25f, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
    //float input = Input.mousePosition.x;
    //GetComponent<Rigidbody>().transform = new Vector3(input, 0);
            GetComponent<Rigidbody>().position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Debug.Log(mousePosition.x + " , " + mousePosition.z);
        }
    }
*/


}
