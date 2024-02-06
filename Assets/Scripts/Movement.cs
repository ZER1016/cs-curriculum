using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public HealthPointScript hpS;
    public bool Overworld;
    public float baseWalkSpeed;
    public float walkSpeed;
    public float xDirection;
    private float xVector;
    public float yDirection;
    private float yVector;
    public KeyCode sprintKey;
    public float sprintSpeed;
    public KeyCode dodgeKey;
    public float ogDodgeTimer;
    public float dodgeTimer;
    public bool dodged;
    public float xfiredirection;
    public float yfiredirection;
    public KeyCode jumpKey;
    public bool grounded;
    public Rigidbody2D rb;
    public LayerMask ground;
    public Vector3 castOrigin;
    
    private void Start()
    {
        dodgeTimer = ogDodgeTimer;
        walkSpeed = baseWalkSpeed;
    }

    void Update()
    {
        if (Input.GetKey(dodgeKey))
        {
            if (dodgeTimer == ogDodgeTimer)
            {
                hpS.iFrames = true;
                dodged = true;
            }
        }

        if (dodged)
        {
            dodgeTimer -= Time.deltaTime;
            if (dodgeTimer < 0)
            {
                dodged = false;
                dodgeTimer = ogDodgeTimer;
            }
        }
        
        
        if (Input.GetKey(sprintKey))
        {
            walkSpeed = baseWalkSpeed + sprintSpeed;
        }
        else
        {
            walkSpeed = baseWalkSpeed;
        }
        xDirection = Input.GetAxis("Horizontal");
        if (xDirection != 0)
        {
            xfiredirection = xDirection;
            yfiredirection = 0;
        }
        xVector = xDirection * walkSpeed * Time.deltaTime;
        
        if (Overworld)
        {
            yDirection = Input.GetAxis("Vertical");
            if (yDirection != 0)
            {
                yfiredirection = yDirection;
                xfiredirection = 0;
            }
            yVector = yDirection * walkSpeed * Time.deltaTime;
        }

        if (!Overworld)
        {
            if (Input.GetKeyDown(jumpKey))
            {
                if (grounded)
                {
                    rb.AddForce(Vector2.up * 8f, ForceMode2D.Impulse);
                }
            }
        }
        
        transform.position = transform.position + new Vector3(xVector, yVector, 0);
        castOrigin = new Vector3(transform.position.x - (xDirection/2.5f), transform.position.y, transform.position.z);
        Debug.DrawRay(castOrigin, -transform.up, Color.red);
        grounded = Physics2D.Raycast(castOrigin, Vector2.down, 0.75f, ground);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = other.gameObject.transform;
        }
        else
        {
            transform.parent = null;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            transform.parent = other.gameObject.transform;
        }
    }
}
