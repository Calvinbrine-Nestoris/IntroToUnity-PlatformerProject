using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public static bool groundTouch = false;
    // Start is called before the first frame update
    void Start()
    {

        

    }
    private void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundTouch = true;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            groundTouch = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        groundTouch = false;
    }
    // Update is called once per frame

}
