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

        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }
        else
        {
            Vector3 movement = new Vector3(Input.acceleration.x, Input.acceleration.z, Input.acceleration.y) * 9.8f;
            Debug.Log(Input.acceleration.x);
            Debug.Log(Input.acceleration.z);
            rb.AddForce(movement, ForceMode.Acceleration);
        }

    }
}
