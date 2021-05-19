using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallScript : MonoBehaviour
{
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        ReturnToCenter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReturnToCenter()
    {
        int velX = Random.Range(1,3) == 1 ? Random.Range(-4, -7) : Random.Range(4,7);
        int velZ = Random.Range(1,3) == 1 ? Random.Range(-4, -7) : Random.Range(4,7);
        
        rb.velocity = new Vector3(velX,0,velZ);
        transform.position = new Vector3(0,0,0);
    }
    
}
