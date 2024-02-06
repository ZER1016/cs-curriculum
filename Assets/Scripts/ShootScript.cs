using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    //public Vector3 targetPos;
    public GameObject projectile;
    public bool shootCooldown;
    public float maxTimer;
    public float timer;
    public bool target;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == true)
        {
            if (shootCooldown == false)
            {
                Instantiate(projectile, new Vector3(transform.position.x,transform.position.y ,transform.position.z ), quaternion.identity);
                shootCooldown = true;
            }
        }

        if (shootCooldown == true)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                shootCooldown = false;
                timer = maxTimer;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = false;
        }
    }
}
