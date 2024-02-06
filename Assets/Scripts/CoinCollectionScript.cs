using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectionScript : MonoBehaviour
{
    public HUD hud;

    private void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            hud.Coins += 1;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Diamond"))
        {
            hud.Coins += 5;
            collision.gameObject.SetActive(false);
        }
    }
}
