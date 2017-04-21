using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PongPaddle : NetworkBehaviour {
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
		//if (this.transform.position == spawnPoints [0].transform.position) 
		if (isServer)
		{
			//cam2.gameObject.SetActive (false);
			//cam1.gameObject.SetActive (true);
			//cam2.enabled = false;
			//cam1.enabled = true;
			Debug.Log ("Server");
		} 
		else 
		{
			//cam1.transform.Rotate (0,0,180);
			//cam1.gameObject.SetActive (false);
			//cam2.gameObject.SetActive (true);
			//cam1.enabled = false;
			//cam2.enabled = true;
			Debug.Log ("Client");
		}
	}
}
