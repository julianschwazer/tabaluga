using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody myRb;
    bool setSpeed;
    [SerializeField] float speedUp;
    float xSpeed;
    float ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(GameController.instance.inPlay == true)
        //{
            if (!setSpeed)
            {
                setSpeed = true;

                xSpeed = Random.Range(1f, 2f) * Random.Range(0, 2) * 2 - 1;
                ySpeed = Random.Range(1f, 2f) * Random.Range(0, 2) * 2 - 1;
            }
            MoveBall();
        //}
    }

    void MoveBall()
    {
        myRb.velocity = new Vector2(xSpeed, ySpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Wall")
        {
            xSpeed = xSpeed * -1;
        }

        if (other.transform.tag == "Player")
        {
            ySpeed = ySpeed * -1;
            if(ySpeed > 0)
            {
                ySpeed += speedUp;
            }
            else
            {
                ySpeed -= speedUp;
            }
            if(xSpeed > 0)
            {
                xSpeed += speedUp;
            }
            else
            {
                xSpeed -= speedUp;
            }
        }
        
    }

    
}
