using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public Movement pms;
    public GameObject self;
    public Collider2D fireballCollider;
    [SerializeField] Vector3 targetLocation;
    [SerializeField] float lifeSpan;
    
    private void Start()
    {
        pms = GameObject.FindObjectOfType<Movement>();
        if (pms.yfiredirection > 0)
        {
            targetLocation = new Vector3(transform.position.x, transform.position.y + 1000, transform.position.z);
        }
        else if (pms.yfiredirection < 0)
        {
            targetLocation = new Vector3(transform.position.x, transform.position.y - 1000, transform.position.z);
        }
        else if (pms.xfiredirection > 0)
        {
            targetLocation = new Vector3(transform.position.x + 1000, transform.position.y, transform.position.z);
        }
        else if (pms.xfiredirection < 0)
        {
            targetLocation = new Vector3(transform.position.x - 1000, transform.position.y, transform.position.z);
        }
        else
        {
            targetLocation = transform.position;
        }
    }

    void Update()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 5.95)
        {
            fireballCollider = GetComponent<Collider2D>();
            fireballCollider.isTrigger = false;
        }
        if (lifeSpan < 0)
        {
            Destroy(self);
        }
        
        transform.position = Vector3.MoveTowards(transform.position, targetLocation, 0.01f);
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(self);
        }
    }
}
