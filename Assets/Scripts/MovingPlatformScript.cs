using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public Vector3 point1;
    public Vector3 point2;
    public bool point;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (point)
            transform.position = Vector3.MoveTowards(transform.position, point1, (speed * 0.001f));
        else if (!point)
            transform.position = Vector3.MoveTowards(transform.position, point2, (speed * 0.001f));

        if (point && Vector3.Distance(transform.position, point1) < 1)
        {
            point = false;
        }
        
        if (!point && Vector3.Distance(transform.position, point2) < 1)
        {
            point = true;
        }
        
    }
    
}
