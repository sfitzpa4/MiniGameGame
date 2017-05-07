using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PongBall : NetworkBehaviour {

	public float ballInitVelocity = 600f;

	private Rigidbody rb;
	private bool ballInPlay = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		transform.parent = null;
		rb.isKinematic = false;
		rb.AddForce (new Vector3 (ballInitVelocity, ballInitVelocity, 0));
		ballInPlay = true;
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
