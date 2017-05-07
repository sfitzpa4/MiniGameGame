using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PongManager : NetworkBehaviour {

	public GameObject camera;
	public GameObject ball;
	public GameObject scoreCanvas;
	private GameObject winner;
	private GameObject player1ScoreText;
	private GameObject player2ScoreText;

	private GameObject cloneCamera;
	private GameObject cloneBall;
	private GameObject cloneScoreCanvas;
	private GameObject clonePlayer1Score;
	private GameObject clonePlayer2Score;
	private GameObject cloneWinner;
	private bool gameStarted = false;
	private int player1Score = 0;
	private int player2Score = 0;
	private float resetDelay = 1f;

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
		Debug.Log ("PongManager");
	}
	
	// Update is called once per frame
	void Update () {
		if (isServer && gameStarted == false && NetworkServer.connections.Count == 2) {
			Debug.Log ("Connected");
			CmdSpawnBall ();
			CmdSpawnScoreCanvas ();
			gameStarted = true;
		}
		CheckForPoint ();
		UpdateScores ();
	}

	[Command]
	void CmdSpawnBall()
	{
		cloneBall = Instantiate (ball, ball.transform.position, Quaternion.identity);
		NetworkServer.Spawn (cloneBall);
	}

	[Command]
	void CmdUnSpawnBall()
	{
		NetworkServer.UnSpawn (cloneBall);
		Destroy (cloneBall);
	}

	[Command]
	void CmdSpawnScoreCanvas()
	{		
		cloneScoreCanvas = Instantiate (scoreCanvas, scoreCanvas.transform.position, Quaternion.identity);
		NetworkServer.Spawn (cloneScoreCanvas);
	}

	[Command]
	void CmdUpdateScoreCanvas()
	{
		NetworkServer.Spawn (cloneScoreCanvas);
	}

	void UpdateScores()
	{
		PongScore pongScore = cloneScoreCanvas.transform.GetChild (0).GetComponent<PongScore>();
		pongScore.setScore (player1Score);
		PongScore pongScore2 = cloneScoreCanvas.transform.GetChild (2).GetComponent<PongScore>();
		pongScore2.setScore (player2Score);
	}

	void CheckForPoint()
	{
		if (cloneBall == null) {
			return;
		}	
		if (cloneBall.transform.position.y > 15) 
		{
			CmdUnSpawnBall ();
			Debug.Log ("Player 1 Scored");
			player1Score++;
			//player1ScoreText.GetComponent<Text>().text = player1Score.ToString ();
			if (player1Score == 3) {
				if (isServer) {
					cloneScoreCanvas.transform.GetChild (1).gameObject.SetActive (true);
				} else {
					//loser.SetActive (true);
				}
			} else {
				Invoke ("CmdSpawnBall", resetDelay);
			}
			//CmdUpdateScoreCanvas ();
		}
		else if(cloneBall.transform.position.y < -15)
		{
			CmdUnSpawnBall ();
			Debug.Log ("Player 2 Scored");
			player2Score++;
			//player2ScoreText.GetComponent<Text>().text = player2Score.ToString ();
			cloneScoreCanvas.transform.GetChild (2).GetComponent<Text>().text = player2Score.ToString ();
			if (player2Score == 3) {
				if (isServer) {
					cloneScoreCanvas.transform.GetChild (1).GetComponent<Text> ().text = "YOU LOSE!";
					cloneScoreCanvas.transform.GetChild (1).gameObject.SetActive (true);
				} else {
					//winner.SetActive (true);
				}
			} else {
				Invoke ("CmdSpawnBall", resetDelay);
			}
			//CmdUpdateScoreCanvas ();
		}
	}
}
