using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PongManager : NetworkBehaviour {

	public GameObject camera;
	public GameObject ball;
	public GameObject networkManager;

	private GameObject cloneCamera;
	private GameObject cloneBall;
	private bool gameStarted = false;
	private int playerCount = 0;

	public static PongManager instance = null;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy(gameObject);
		}
		cloneCamera = Instantiate(camera, camera.transform.position, Quaternion.identity) as GameObject;
		cloneCamera.GetComponent<PongCamera> ().SetCamera ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameStarted == false && NetworkServer.connections.Count == 2) {
			Debug.Log ("Connected");
			cloneBall = Instantiate (ball, ball.transform.position, Quaternion.identity) as GameObject;
			NetworkServer.Spawn (cloneBall);
			gameStarted = true;
		}
	}
}
