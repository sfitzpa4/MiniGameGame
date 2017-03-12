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
        float moveHorizontal = Input.acceleration.x;
        float moveVertical = Input.acceleration.z;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, (-moveVertical-0.50f));
        Debug.Log(-moveVertical);
        rb.AddForce(movement * speed);
        
    }
}
