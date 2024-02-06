using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeSwingScript : MonoBehaviour
{
    public AxeScript axe;
    public KeyCode swingKey;
    public float timer;
    public float ogTimer;
    public bool axeSwing;
    private void Update()
    {
        if (Input.GetKeyDown(swingKey) && axe.axeItem)
        {
            timer = ogTimer;
            axeSwing = true;
        }

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            axeSwing = false;
        }
    }
}
