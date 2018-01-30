using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallavoidbehavior : MonoBehaviour {
   wander wander;
    Rigidbody rb;
    public float avoidanceStrength;
    public float avoidanceRange;
    // Use this for initialization
    void Start()
    {
        wander = GetComponent<wander>();
        rb = GetComponent<Rigidbody>();
    }


    public void doWallAvoidance()
    {
        RaycastHit hit;
        //Raycasts a sphere infront of us
        if (Physics.SphereCast(transform.position, 1, transform.forward, out hit, avoidanceRange))
        {
            //Add a force away from the wall
            rb.AddForce(hit.normal * avoidanceStrength);
        }


    }

}
