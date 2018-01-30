using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seek : MonoBehaviour {
    Rigidbody rb;
    Vector3 desired;
    public float speed;
    public Transform target;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        desired = speed * (target.position - transform.position).normalized;
        rb.AddForce(desired - rb.velocity);
	}
}
