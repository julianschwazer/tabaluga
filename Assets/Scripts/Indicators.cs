using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Indicators : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 5f; // delay before the GAME starts
    private float _timeElapsed; // elapsed time

    void Update()
    {
        _timeElapsed += Time.deltaTime;

        if( _timeElapsed > delayBeforeLoading)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // loading next scene
        }
    }
}
