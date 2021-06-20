using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    // variables for the Countdown
    public int countdownTime;
    public TextMeshProUGUI countdownTextFloor, countdownTextWall;
    public GameObject delayedObject;
    public int delay;

    void Start()
    {
        // PLAY BackgroundMusic and Countdown audio file
        FindObjectOfType<AudioManager>().Play("BackgroundMusic");
        FindObjectOfType<AudioManager>().Play("Countdown");
        
        // coroutines for COUNTDOWN and delaying the start of the BALL
        StartCoroutine(CountdownStart());
        StartCoroutine(StartDelay());
    }

    IEnumerator CountdownStart()
    {
        while (countdownTime > 0) {
            countdownTextFloor.text = countdownTextWall.text = countdownTime.ToString(); // set text to countdown number
            yield return new WaitForSecondsRealtime(1f); // wait for a second
            countdownTime--; // decrease countdown time by a second
        }
        
        // CHANGE countdown TEXT to Go!
        countdownTextFloor.text = countdownTextWall.text = "Go!";
        
        yield return new WaitForSecondsRealtime(1f); // wait for another second
        
        // HIDING the countdown text when the game starts
        countdownTextFloor.gameObject.SetActive(false);
        countdownTextWall.gameObject.SetActive(false);

         // GAME STARTS HERE
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0; // pause GAME
        
        // delaying the game start
        float pauseTime = Time.realtimeSinceStartup + delay;
        while (Time.realtimeSinceStartup < pauseTime) {
            yield return 0;
        }
        
        delayedObject.gameObject.SetActive(true); // activate BALL
        Time.timeScale = 1; // play GAME
    }
}