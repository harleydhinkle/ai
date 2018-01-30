using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wander : MonoBehaviour {

    Rigidbody rb;
    public float dis;
    public float radius;
    public float speed;
    public float jitter;
    //public float wadertime;
    public Vector3 target;
    //float timer;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
    void Update () {
        target = Vector3.zero;
        target = Random.insideUnitCircle.normalized * radius;
        target = (Vector2)target + Random.insideUnitCircle * jitter;

        target.z = target.y;
        target += transform.position;
        target += transform.forward * dis;
        target.y = 0;
        Vector3 dir = (target - transform.position).normalized;
        Vector3 desiredvel = dir * speed;

        rb.AddForce(desiredvel - rb.velocity);
        transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z); 
        //transform.LookAt(rb.velocity);
        //transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);

    }
}
