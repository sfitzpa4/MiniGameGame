using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PongPaddle : NetworkBehaviour {

	public float paddleSpeed = 0.1f;
	private Vector3 playerPos = new Vector3 (0, -9.5f, 0);

	private NetworkStartPosition[] spawnPoints;
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer) 
		{
			return;
		}

		if (Application.isMobilePlatform)
		{
			foreach (Touch touch in Input.touches) {
				if (touch.position.x < Screen.width / 2) {
					float xPos = transform.position.x + (-1 * paddleSpeed);
					float yPos = transform.position.y;
					playerPos = new Vector3 (Mathf.Clamp (xPos, -2.2f, 2.2f), yPos, 0f);
					transform.position = playerPos;
					//var x = -1 * Time.deltaTime * 5.0f;
					//transform.Translate(x, 0, 0);
				} else if (touch.position.x > Screen.width / 2) {
					float xPos = transform.position.x + (1 * paddleSpeed);
					float yPos = transform.position.y;
					playerPos = new Vector3 (Mathf.Clamp (xPos, -2.2f, 2.2f), yPos, 0f);
					transform.position = playerPos;
					//var x = 1 * Time.deltaTime * 5.0f;
					//transform.Translate(x, 0, 0);
				}
			}
		} 
		else
		{
			//var x = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
			//transform.Translate(x, 0, 0);
			float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
			float yPos = transform.position.y;
			playerPos = new Vector3 (Mathf.Clamp (xPos, -2.2f, 2.2f), yPos, 0f);
			transform.position = playerPos;
		}
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

		if (Application.platform == RuntimePlatform.IPhonePlayer) 
		{
			this.transform.Translate (0, 0, -0.1f);
		}
		this.transform.Translate (0, 0, -1f);
	}
}
