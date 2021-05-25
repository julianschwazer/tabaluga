using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    // Countdown Variables
    public int countdownTime;
    public TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownStart());
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
            yield return new WaitForSeconds(1f); // wait for a second
            countdownTime--; // decrease countdown time by a second
        }

        countdownText.text = "Go!"; // change countdown to GO
        yield return new WaitForSeconds(1f); // wait for another second
        countdownText.gameObject.SetActive(false); // hide text
        
        // START GAME HERE
    }
}
