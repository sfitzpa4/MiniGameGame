using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerInput : MonoBehaviour {

    public bool isFlat = true;
    public float speed;
    private Rigidbody rigidb;

    void Awake ()
    {
        rigidb = GetComponent<Rigidbody>();
    }
	// Update is called once per frame
	void Update () {

        //Vector3 tilt = Input.acceleration;

        //if (isFlat)
        //{
            //tilt = Quaternion.Euler(90, 0, 0) * tilt;
        //}
        Vector3 movement = new Vector3(Input.acceleration.x * 5, 0.0f, Input.acceleration.y * 5);
        //Debug.Log(Input.acceleration.x);
        //Debug.Log(Input.acceleration.y);
        rigidb.AddForce(movement * speed * Time.deltaTime);
        //rigidb.AddForce(tilt);
        

    }
}
