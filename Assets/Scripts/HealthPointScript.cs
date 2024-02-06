using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPointScript : MonoBehaviour
{
    public bool iFrames;
    public HUD hud;
    public float timer;
    public float ogTimer;

    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        timer = ogTimer;
    }

    void Update()
    {
        if (iFrames)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                iFrames = false;
                timer = ogTimer;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            ChangeHealth(1);
        }

        if (collision.gameObject.CompareTag("MoltenSpikes"))
        {
            ChangeHealth(2);
        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ChangeHealth(2);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("AddHealth"))
        {
            if (hud.health < hud.maxHealth)
            {
                ChangeHealth(-3);
                collision.gameObject.SetActive(false);
            }
        }
    }
    

void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            hud.health -= amount;
            if (hud.health > hud.maxHealth)
            {
                hud.health = hud.maxHealth;
            }
        }
        else if (!iFrames)
        {
            iFrames = true;
            hud.health -= amount;
        }

        if (hud.health <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

//void Knockback
//detect which side the "other" is on and move in opposite direction
}
