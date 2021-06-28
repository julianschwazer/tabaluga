using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class BallScript : MonoBehaviour
{
    // variables
    Rigidbody _rb;
    float velX;
    float velZ;

    // bulletproofing
    private int hitCounter;
    public int maxHitCount;
    public GameObject tspsObject;
    
    // score variables
    private int _scoreLeft, _scoreRight;
    public int _scoreMax;
    
    // interface TEXT variables for FLOOR and WALL
    public TextMeshProUGUI scoreLeftTextFloor, scoreLeftTextWall;
    public TextMeshProUGUI scoreRightTextFloor, scoreRightTextWall;
    public TextMeshProUGUI winnerTextFloor,winnerTextWall;

    public float sceneReloadDelay;
    
    void Start()
    {
        hitCounter = 0; // reset variable
            
        // reset scores
        scoreLeftTextFloor.text = scoreLeftTextWall.text = scoreRightTextFloor.text = scoreRightTextWall.text = 0.ToString();

        _rb = GetComponent<Rigidbody>(); // assign component to variable
        
        ResetScore(); // reset score
        ReturnToCenter(); // reset ball location and start it in random direction
    }

    void Update()
    {
        // END of game based on the score
        if (_scoreLeft >= _scoreMax)
        {
            // enable WINNER text elements
            winnerTextFloor.gameObject.SetActive(true);
            winnerTextWall.gameObject.SetActive(true);
            
            // WINNER text and load indicator scene
            winnerTextFloor.text = winnerTextWall.text = "LEFT TEAM WINS";
            StartCoroutine(ReloadGame());

        }
        else if (_scoreRight >= _scoreMax)
        {
            // enable WINNER text elements
            winnerTextFloor.gameObject.SetActive(true);
            winnerTextWall.gameObject.SetActive(true);
            
            // WINNER text and load indicator scene
            winnerTextFloor.text = winnerTextWall.text = "RIGHT TEAM WINS";
            StartCoroutine(ReloadGame());
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
        hitCounter = 0; // reset variable
        
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
        scoreLeftTextFloor.text = scoreLeftTextWall.text = _scoreLeft.ToString();
        scoreRightTextFloor.text = scoreRightTextWall.text = _scoreRight.ToString();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hitCounter = 0; // reset variable
            
            // PLAY PaddleHit audio file
            FindObjectOfType<AudioManager>().Play("PaddleHit");
            
            // if the ball collides with one of the paddles
            velX += velX * 2;
            velZ += velZ * 2;

        }

        if (other.gameObject.CompareTag("Goal"))
        {
            // PLAY Goal audio file
            FindObjectOfType<AudioManager>().Play("Goal");
            
            // if the ball hits the goal - increase score and return ball to center
            if (_rb.position.x > 0)
            {
                _scoreRight++;
                scoreRightTextFloor.text = scoreRightTextWall.text = _scoreRight.ToString();
                ReturnToCenter();
            }
            else
            {
                _scoreLeft++;
                scoreLeftTextFloor.text = scoreLeftTextWall.text = _scoreLeft.ToString();
                ReturnToCenter();
            }
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            hitCounter++;
            if (hitCounter >= maxHitCount)
            {
                ReturnToCenter();
            }
            
            // PLAY PaddleHit audio file with different pitch for the WallHit
            FindObjectOfType<AudioManager>().Play("WallHit");
        }
    }
    
    IEnumerator ReloadGame()
    {
        // waiting for some seconds and reload the scene
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(sceneReloadDelay);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        // destroy and instantiate tsps script again
        Destroy(tspsObject);
        Instantiate(tspsObject);

    }
}
