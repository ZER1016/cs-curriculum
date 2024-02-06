using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnedScript : MonoBehaviour
{
    public Collider2D thisCollider;
    public float cTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        thisCollider = GetComponent<Collider2D>();
        thisCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cTimer > 0)
        {
            cTimer -= Time.deltaTime;
            if (cTimer <= 0)
            {
                thisCollider.isTrigger = true;
            }
        }
    }
}
