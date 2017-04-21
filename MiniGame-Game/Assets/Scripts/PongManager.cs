using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongManager : MonoBehaviour {

	public GameObject camera;
	private GameObject cloneCamera;

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
		
	}
}
