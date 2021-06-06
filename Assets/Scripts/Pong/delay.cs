using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delay : MonoBehaviour
{
    public GameObject Delay;
    //public float duration 3f;
    //bool _isFrozen = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartDelay");

    }

    // Update is called once per frame
    void Update()
    {
        //if(_pendingFreezeDuration < 0 && !isFrozen)
        //{
        //    StartCoroutine(DoFreeze())
        //}

        //float _pendingFreezeDuration = 0f;
        //public void Freeze()
        //{
        //    _pendingFreezeDuration = duration;
        //}

        IEnumerator StartDelay()
        {

            Time.timeScale = 0;
            float pauseTime = Time.realtimeSinceStartup + 3f;
            while (Time.realtimeSinceStartup < pauseTime)
                yield return 0;
            Delay.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
