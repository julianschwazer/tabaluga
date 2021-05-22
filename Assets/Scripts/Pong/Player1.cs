using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public string leftKey, rightKey;
    public float speed;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        //if (Input.GetKey(leftKey) && transform.position.x > 5)
        if (Input.GetKey(leftKey) && transform.position.x > 5)

            {
                transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self);
        }
        if (Input.GetKey(rightKey) && transform.position.x < 6.8)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
        }
    }
}
