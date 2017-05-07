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
	private int player1Score = 0;
	private int player2Score = 0;

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
		if (isServer && gameStarted == false && NetworkServer.connections.Count == 2) {
			Debug.Log ("Connected");
			CmdSpawnBall ();
			gameStarted = true;
		}
		CheckForPoint ();
	}

	[Command]
	void CmdSpawnBall()
	{
		cloneBall = Instantiate (ball, ball.transform.position, Quaternion.identity);
		NetworkServer.Spawn (cloneBall);
	}

	void CheckForPoint()
	{
		if (cloneBall == null) {
			return;
		}
		if (cloneBall.transform.position.y > 15) 
		{
			Debug.Log ("Player 1 Scored");
			player1Score++;
		}
		else if(cloneBall.transform.position.y < -15)
		{
			Debug.Log ("Player 2 Scored");
			player2Score++;
		}
	}
}
