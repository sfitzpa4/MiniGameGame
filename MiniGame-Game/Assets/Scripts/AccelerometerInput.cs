using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerInput : MonoBehaviour {

    public float speed = 1f;
    private Rigidbody rb;

    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
    }
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3(Input.acceleration.x, 0.0f, -Input.acceleration.z);
        rb.AddForce(movement * speed);
    }
}
