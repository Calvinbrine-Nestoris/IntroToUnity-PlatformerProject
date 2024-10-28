using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedx;
    public float speedy;
    public new Vector3 gravity;
    private Rigidbody2D rb;
    public static bool doubleJump = false;
    bool djumpAvail = false;
    public static bool dash = false;
    double dashTimer = 0.2;
    bool dashEnable = true;
    bool dashActive = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speedx = 20;
        speedy = 210;
        if (dashActive == true)
        {
            speedx *= 6;
            speedy = 0;
            gravity = new Vector2(0, 0);
            dashTimer -= Time.deltaTime;
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        else if (GroundDetector.groundTouch == false)
        {
            gravity = new Vector2(0, -0.5f);
            rb.velocity += new Vector2(0, gravity.y);
        }
        else
        {
            gravity = new Vector2(0, 0);
        }
        if (Input.GetKey("left"))
        {
             rb.velocity = new Vector2(-speedx, rb.velocity.y);
        }
        if (Input.GetKey("right"))
        {
                rb.velocity = new Vector2(speedx, rb.velocity.y);
        }
        
        if (Input.GetKeyDown("up"))
        {
            if (GroundDetector.groundTouch == true)
            {
                gravity = new Vector2(0, 0);
                rb.velocity += new Vector2(0, speedy);
                djumpAvail = true;
            }
            else if (doubleJump == true && djumpAvail == true)
            {
                rb.velocity += new Vector2(0, speedy);
                djumpAvail = false;
            }
            
        }
        if (Input.GetKeyDown("space"))
        {
            if (GroundDetector.groundTouch == true)
            {
                gravity = new Vector2(0, 0);
                rb.velocity += new Vector2(0, speedy);
                djumpAvail = true;
            }
            else if (doubleJump == true && djumpAvail == true)
            {
                gravity = new Vector2(0, 0);
                rb.velocity += new Vector2(0, speedy);
                djumpAvail = false;
            }
        }
        if (Input.GetKeyDown("left shift") && dashEnable == true && dash == true)
        {
            dashActive = true;
        }
        if (dashTimer <= 0)
        {
            dashActive = false;
            dashEnable = false;
        }
        if (dashEnable == false)
        {
            dashTimer += 0.2 * Time.deltaTime;
        }
        if (dashTimer >= 0.2)
        {
            dashEnable = true;
            dashTimer = 0.2;
        }
    }
}
