using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrive : MonoBehaviour
{

    Rigidbody rb;
    public float speed;
    public Transform target;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targertoffset = target.position - transform.position;
        float dist = Vector3.Distance(transform.position, target.position);
        float rampedspeed = speed * (targertoffset.magnitude / dist);
        float clippspeed = Mathf.Min(rampedspeed, speed);
        Vector3 desiredv = (clippspeed / targertoffset.magnitude) * targertoffset;
        rb.velocity = desiredv;

    }
}
