using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody _myRb;
    bool _setSpeed;
    [SerializeField] float speedUp;
    float _xSpeed;
    float _ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        _myRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(GameController.instance.inPlay == true)
        //{
        if (!_setSpeed)
        {
            _setSpeed = true;

            _xSpeed = Random.Range(1f, 2f) * Random.Range(0, 2) * 2 - 1;
            _ySpeed = Random.Range(1f, 2f) * Random.Range(0, 2) * 2 - 1;
        }

        MoveBall();
        //}
    }

    void MoveBall()
    {
        _myRb.velocity = new Vector2(_xSpeed, _ySpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Wall")
        {
            _xSpeed = _xSpeed * -1;
        }

        if (other.transform.tag == "Player")
        {
            _ySpeed = _ySpeed * -1;
            if (_ySpeed > 0)
            {
                _ySpeed += speedUp;
            }
            else
            {
                _ySpeed -= speedUp;
            }

            if (_xSpeed > 0)
            {
                _xSpeed += speedUp;
            }
            else
            {
                _xSpeed -= speedUp;
            }
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy") 
    //    {
    //        rb.AddForce(200,200,200,ForceMode.Force);
    //    }
    //}
}
