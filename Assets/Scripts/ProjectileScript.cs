using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject self;
    [SerializeField] Vector3 targetLocation;
    [SerializeField] private float lifeSpan;
    [SerializeField] private LayerMask ground;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            targetLocation = other.gameObject.transform.position;
        }
    }

    void Update()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0)
        {
            Destroy(self);
        }

        if (transform.position == targetLocation)
        {
            Destroy(self);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetLocation, 0.005f);
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && lifeSpan < 7.5)
        {
            Destroy(self);
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            //NOT WORKING???
            Destroy(self);
        }
    }
}
