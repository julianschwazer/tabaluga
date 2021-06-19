using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Indicators : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 5f;
    [SerializeField]
    //public string sceneNameToLoad;

    private float timeElapsed;

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if( timeElapsed > delayBeforeLoading)
        {
            //SceneManager.LoadScene(sceneNameToLoad);
            SceneManager.LoadScene("NEWPong");
        }
    }
}
