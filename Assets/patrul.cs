using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrul : MonoBehaviour {
    public Transform[] patrolpoints;
    public float movespeed;
    private int currentpoint;
    public Transform target;
    public float dist2;
    Rigidbody rb;
    // Use this for initialization
    void Start () {
        transform.position = patrolpoints[currentpoint].position;
        currentpoint = 0;
        rb = GetComponent<Rigidbody>();
        target = patrolpoints[currentpoint];
    }
	
	// Update is called once per frame
	void Update () {
        dist2 = Vector3.Distance(transform.position, target.position);
        if (dist2 < 1)
        {
            currentpoint++;
            if (currentpoint == patrolpoints.Length )
            {
                currentpoint = 0;
                //target = patrolpoints[currentpoint];
            }
            target = patrolpoints[currentpoint];
        }
        Vector3 targertoffset = patrolpoints[currentpoint].position - transform.position;
        float dist = Vector3.Distance(transform.position, patrolpoints[currentpoint].position);
        float rampedspeed = movespeed * (targertoffset.magnitude / dist);
        float clippspeed = Mathf.Min(rampedspeed, movespeed);
        Vector3 desiredv = (clippspeed / targertoffset.magnitude) * targertoffset;
        rb.velocity = desiredv;
        //transform.position = Vector3.MoveTowards(transform.position, patrolpoints[currentpoint].position, movespeed * Time.deltaTime);
    }
}
