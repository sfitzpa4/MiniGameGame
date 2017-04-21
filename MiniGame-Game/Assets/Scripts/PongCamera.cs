using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PongCamera : NetworkBehaviour {

	bool camSet = false;

	private NetworkStartPosition[] spawnPoints;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (isServer);
		if (Input.GetKeyDown(KeyCode.C)) {
			transform.Rotate (0, 0, 180);
			Debug.Log ("C");
		}
		if (!camSet && isServer) 
		{
			Debug.Log (camSet + ", Server");
			camSet = true;
			Debug.Log (camSet + ", Server");
		} 
		else if (!camSet && isClient) 
		{
			transform.Rotate (0, 0, 180);
			Debug.Log (camSet + ", Client");
			camSet = true;
			Debug.Log (camSet + ", Client");
		}
	}

	public void SetCamera()
	{
		spawnPoints = FindObjectsOfType<NetworkStartPosition> ();
		if (this.transform.position == spawnPoints [0].transform.position) 
		{
		} 
		else 
		{
			//transform.Rotate (0, 0, 180);
		}
	}
}
