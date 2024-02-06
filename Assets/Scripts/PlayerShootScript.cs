using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public KeyCode shootKey;
    public GameObject playerFireball;
    public bool cooldown;
    public float cooldownTimer;
    public float ogCooldownTimer;

    private void Start()
    {
        cooldownTimer = ogCooldownTimer;
    }

    void Update()
    {
        if (!cooldown)
        {
         if (Input.GetKeyDown(shootKey))
         {
             Instantiate(playerFireball, transform.position, transform.rotation);
             cooldown = true;
         }   
        }
        
        if (cooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer < 0)
            {
                cooldownTimer = ogCooldownTimer;
                cooldown = false;
            }
        }
    }

}
