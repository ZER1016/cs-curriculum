using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD hud;
    public int health;
    public int maxHealth;
    public int Coins;
    void Awake()
    {
        if (hud != null && hud != this)
        {
            Destroy(gameObject);
        }
        else
        {
            hud = this;
            health = maxHealth;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    
    public HUD purse;
    public TextMeshProUGUI coinText;
    public HUD hp;
    public TextMeshProUGUI healthText;
    void Update()
    {
        coinText.text= "Coins: " + purse.Coins.ToString();
        healthText.text = "Health: " + hp.health.ToString();
    }
}
