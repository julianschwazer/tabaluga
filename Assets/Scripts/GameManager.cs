using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    // variables for the Countdown
    public int countdownSeconds;
    public TextMeshProUGUI countdownTextFloor, countdownTextWall;
    
    public GameObject delayedObject;
    public GameObject canvasGroup;
    public GameObject indicatorGroup;

    public float indicatorAnimationTime;
    public float goDisplayTime;
    public float ballWaitTime;
    
    void Start()
    {
        // PLAY BackgroundMusic and Countdown audio file
        FindObjectOfType<AudioManager>().Play("BackgroundMusic");
        StartCoroutine(GameStart());
    }

    IEnumerator GameStart()
    {
        // waiting for the INDICATOR ANIMATION and hiding it afterwards
        yield return new WaitForSecondsRealtime(indicatorAnimationTime);
        indicatorGroup.gameObject.SetActive(false);

        // enabling the interface elements and starting the countdown sound
        canvasGroup.gameObject.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Countdown");
        
        // starting the countdown with changing the text every second
        while (countdownSeconds > 0) {
            countdownTextFloor.text = countdownTextWall.text = countdownSeconds.ToString(); // set text to countdown number
            yield return new WaitForSecondsRealtime(1f); // wait for a second
            countdownSeconds--; // decrease countdown time by a second
        }
        
        // change countdown text to GO! and display it for some seconds
        countdownTextFloor.text = countdownTextWall.text = "Go!";
        yield return new WaitForSecondsRealtime(goDisplayTime); // wait for another second
        
        // HIDING the countdown text when the game starts
        countdownTextFloor.gameObject.SetActive(false);
        countdownTextWall.gameObject.SetActive(false);
        
        // waiting for some seconds before the ball gets active and starts moving
        yield return new WaitForSecondsRealtime(ballWaitTime); // wait for another second
        delayedObject.gameObject.SetActive(true);

        // GAME STARTS HERE
    }
}