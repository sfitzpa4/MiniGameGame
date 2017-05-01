using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBall : MonoBehaviour {

	public float ballInitVelocity = 600f;

	private Rigidbody rb;
	private bool ballInPlay = false;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () 
	{
		if (ballInPlay == false) {
			transform.parent = null;
			rb.isKinematic = false;
			rb.AddForce (new Vector3 (ballInitVelocity, ballInitVelocity, 0));
			ballInPlay = true;
		}
	}
}
