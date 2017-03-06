using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1f;
	
	private Vector3 playerPos = new Vector3 (0, -9.5f, 0);
	
	
	// Update is called once per frame
	void Update () {

		foreach (Touch touch in Input.touches) {
			if (touch.position.x < Screen.width/2) {
				
				float xPos = transform.position.x + (-paddleSpeed);
				playerPos = new Vector3 (Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);
				transform.position = playerPos;


			}
			else if (touch.position.x > Screen.width/2) {
				float xPos2 = transform.position.x +(paddleSpeed);
				playerPos = new Vector3 (Mathf.Clamp(xPos2, -8f, 8f), -9.5f, 0f);
				transform.position = playerPos;

			}
		}
	}
}
