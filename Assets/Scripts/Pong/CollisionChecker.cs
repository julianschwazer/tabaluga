using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{


    void start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0, 60 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected!");
        //gameObject.GetComponent<Renderer>().material = redMat;
        GetComponent<Renderer>().material.color = Color.red;
        other.GetComponent<Renderer>().material.color = Color.red;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Collision over!");
        //gameObject.GetComponent<Renderer>().material = greenMat;
        GetComponent<Renderer>().material.color = Color.green;
        other.GetComponent<Renderer>().material.color = Color.green;
    }
}