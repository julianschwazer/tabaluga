using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    // Countdown Variables
    public int countdownTime;
    public TextMeshProUGUI countdownText;
    public GameObject DelayTime;
    public int delay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownStart());
        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountdownStart()
    {
            while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString(); // set text to countdown number
            yield return new WaitForSecondsRealtime(delay); // wait for a second
            countdownTime--; // decrease countdown time by a second
        }

        countdownText.text = "Go!"; // change countdown to GO
        yield return new WaitForSecondsRealtime(1f); // wait for another second
        countdownText.gameObject.SetActive(false); // hide text

         // START GAME HERE
    }

    IEnumerator StartDelay()
    {

        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + delay;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        DelayTime.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
}