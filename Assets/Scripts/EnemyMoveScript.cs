using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{
    public GameObject self;
    [SerializeField] Vector3 targetLocation;
    [SerializeField] bool target;
    [SerializeField] GameObject player;
    [SerializeField] GameObject passiveTrigger;
    [SerializeField] GameObject activeTrigger;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            target = true;
            passiveTrigger.SetActive(false);
            activeTrigger.SetActive(true);
        }
    }

    private void Start()
    {
        targetLocation = this.transform.position;
    }

    void Update()
    {
        if (target)
        {
            targetLocation = player.transform.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetLocation, 0.0033f);
        
        //animations:
        if (targetLocation.x > transform.position.x)
        {
            //Animation Up
        }
        if (targetLocation.x < transform.position.x)
        {
            //Animation Down
        }
        if (targetLocation.y > transform.position.y)
        {
            //Animation Right
        }
        if (targetLocation.y < transform.position.y)
        {
            //Animation Left
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = false;
            targetLocation = this.transform.position;
            passiveTrigger.SetActive(true);
            activeTrigger.SetActive(false);
        }
    }
}
