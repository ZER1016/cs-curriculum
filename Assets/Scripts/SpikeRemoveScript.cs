using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRemoveScript : MonoBehaviour
{
    public KeyCode digButton;
    public float startingDigTimer;
    private float digTimer;
    public GameObject Coin;

    // Update is called once per frame
    void Start()
    {
        digTimer = startingDigTimer;
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            if (Input.GetKey(digButton))
            {
                digTimer -= Time.deltaTime;
                if (digTimer <= 0)
                {
                    collision.gameObject.SetActive(false);
                    digTimer = startingDigTimer;
                    //Instantiate(Coin, collision.transform.position, collision.transform.rotation);
                    //Save this for the actual enemies
                }
            }
        }

        if (collision.gameObject.CompareTag("MoltenSpikes"))
        {
            if (Input.GetKey(digButton))
            {
                digTimer -= Time.deltaTime;
                if (digTimer <= 0)
                {
                    //collision.gameObject.SetActive(false);
                    //Molten Spikes should stay, more dangerous that way
                    digTimer = startingDigTimer;
                }
            }
        }
    }
}
