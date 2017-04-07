using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PongPaddle : NetworkBehaviour {

	public Camera cam1;
	public Camera cam2;
	private NetworkStartPosition[] spawnPoints;
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) 
		{
			return;
		}
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
		transform.Translate(x, 0, 0);
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.green;
		spawnPoints = FindObjectsOfType<NetworkStartPosition> ();
		if (this.transform.position == spawnPoints [0].transform.position) 
		{
			cam1.enabled = true;
			cam2.enabled = false;
			cam1.tag = "MainCamera";
			cam2.tag = "Untagged";
		} 
		else 
		{
			cam2.enabled = true;
			cam1.enabled = false;
			cam2.tag = "MainCamera";
			cam1.tag = "Untagged";
		}
	}
}
