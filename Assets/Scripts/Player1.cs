using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player1 : MonoBehaviour
{
    public string leftKey, rightKey;
    public float speed;

    //NEW Input Manager
    private Rigidbody m_playerRigidbody = null;
    private float m_movementX, m_movementY; //input vector components

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    // OLD Input Manager
    void PlayerMovement()
    {
        if (Input.GetKey(leftKey) && transform.position.x > 5)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self);
        }
        if (Input.GetKey(rightKey) && transform.position.x < 6.8)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
        }
    }

    // NEW Input Manager (PlayerInput Actions)

    /*
     private void Start()
    {
        //frozen = false;
        m_playerRigidbody = GetComponent<Rigidbody>(); //get the rigidbody component

       // m_collectablesTotalCount = m_collectablesCounter = GameObject.FindGameObjectsWithTag("Collectable").Length; //find all gameobjects in the scene which are tagged with "Collectable" and count them via Length property 
        
      //  m_stopwatch = Stopwatch.StartNew(); //start the stopwatch
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 movementVector = inputValue.Get<Vector2>(); //get the input
       
             //split input vector in its two components
            m_movementX = movementVector.x;
            m_movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(m_movementX, 0f, m_movementY); //translate the 2d vector into a 3d vector

        
        m_playerRigidbody.AddForce(movement * m_speed); //apply a force to the rigidbody

        
        
    }
     */
}
