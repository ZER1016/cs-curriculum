using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDestroyScript : MonoBehaviour
{
    public AxeSwingScript axeSwing;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            axeSwing = other.gameObject.GetComponent<AxeSwingScript>();
            if (axeSwing.axeSwing)
            {
                //Debug.Log("destroy");
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        axeSwing = null;
    }
}
