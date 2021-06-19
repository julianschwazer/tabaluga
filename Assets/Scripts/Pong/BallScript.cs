using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class BallScript : MonoBehaviour
{
    // Variables
    Rigidbody _rb;
    float velX;
    float velZ;

    // Score Variables
    private int _scoreLeft, _scoreRight;
    public int _scoreMax;


    // Interface Text Variables
    public TextMeshProUGUI scoreLeftText;
    public TextMeshProUGUI scoreRightText;
    
    
    void Start()
    {
       
        _rb = GetComponent<Rigidbody>(); // assign component to variable
        
        ResetScore(); // reset score
        ReturnToCenter(); // reset ball location and start it in random direction
    }

    void Update()
    {
        
        // END of game based on the score
        if (_scoreLeft >= _scoreMax)
        {
            Debug.Log("LEFT has won");
            SceneManager.LoadScene("Indicator");
            // YOU WIN and END GAME
        }
        else if (_scoreRight >= _scoreMax)
        {
            Debug.Log("Right has won");
            SceneManager.LoadScene("Indicator");
            // YOU WIN and END GAME
        }
       // MoveBall();
    }

    /*void MoveBall()
    {
        _rb.velocity = new Vector3(_xSpeed,0, _ySpeed);
    }
    */

    void ReturnToCenter()
    {
        // flip a coin and shoot the ball either in the left or right direction
         velX = Random.Range(1,3) == 1 ? Random.Range(-4, -7) : Random.Range(4,7);
         velZ = Random.Range(1,3) == 1 ? Random.Range(-4, -7) : Random.Range(4,7);
        
        _rb.velocity = new Vector3(velX,0,velZ); // apply movement to ball
        transform.position = new Vector3(0,0,0); // reset ball to game center
    }

    void ResetScore()
    {
        // reset score variables
        _scoreLeft = 0;
        _scoreRight = 0;
        
        // reset score texts
        scoreLeftText.text = _scoreLeft.ToString();
        scoreRightText.text = _scoreRight.ToString();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // if the ball collides with one of the paddles
            velX += velX * 1;
            velZ += velZ *1;

        }

        if (other.gameObject.CompareTag("Goal"))
        {
            // if the ball hits the goal - increase score and set ball to center
            if (_rb.position.x > 0)
            {
                _scoreRight++;
                scoreRightText.text = _scoreRight.ToString();
                ReturnToCenter();
            }
            else
            {
                _scoreLeft++;
                scoreLeftText.text = _scoreLeft.ToString();
                ReturnToCenter();
            }
            
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            // if the ball collides with the walls
        }

    }


}
