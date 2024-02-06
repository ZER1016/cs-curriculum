using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHpScript : MonoBehaviour
{
    public int hp = 1;
    public GameObject Coin;
    public GameObject Heart;
    [SerializeField] float drop;
    public HUD playerHealth;
    public bool axe;
    public GameObject axeObject;

    private void Start()
    {
        playerHealth = GameObject.FindObjectOfType<HUD>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Attack"))
        {
            Health(1);
        }
    }

    void Health(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            if (axe)
            {
                Instantiate(axeObject, transform.position, transform.rotation);
            }
            
            else if (playerHealth.health < playerHealth.maxHealth && !axe)
            {
                drop = Random.Range(0, 13);
                if (drop < 3)
                {
                    // do nothing
                }
                else if (drop <= 9 && drop > 3)
                    Instantiate(Coin, transform.position, transform.rotation);
                else if (drop > 9)
                    Instantiate(Heart, transform.position, transform.rotation);
            }
            else if (playerHealth.health >= playerHealth.maxHealth && !axe)
                Instantiate(Coin, transform.position, transform.rotation);
            
            this.gameObject.SetActive(false);
        }
    }
}
