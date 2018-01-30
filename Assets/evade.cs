using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evade : MonoBehaviour {
    Rigidbody rb;
    Vector3 desired;
    public float speed;
    public float bspeed;
    float currentspeed;
    public Transform target;
    public Rigidbody targetrb;
    public float pd;
    Vector3 tragetp;
    float dist;
    public float ad;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetrb = target.GetComponent<Rigidbody>();
        currentspeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, target.position);
        if (dist > ad)
        {
            currentspeed = speed;
            tragetp = targetrb.position - (targetrb.velocity.normalized * pd);
            desired = currentspeed * (tragetp + transform.position).normalized;
            rb.AddForce(desired - rb.velocity);
        }
        else
        {
            currentspeed = bspeed;
            desired = currentspeed * (target.position + transform.position).normalized;
            rb.AddForce(desired - rb.velocity);
        }


    }
}
