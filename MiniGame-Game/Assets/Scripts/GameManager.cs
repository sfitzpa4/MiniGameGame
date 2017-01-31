using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public GameObject paddle;
	public GameObject bricksPrefab;
	public static GameManager instance = null;

	private GameObject clonePaddle;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		Setup ();
	}

	public void Setup()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate (bricksPrefab, transform.position, Quaternion.identity);
	}

	void IsGameOver()
	{
	}

	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel (Application.loadedLevel);
	}
	
	public void LoseLife()
	{
		lives--;
		Destroy (clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		IsGameOver ();
	}

	public void DestroyBrick()
	{
		bricks--;
		IsGameOver ();
	}

	void SetupPaddle()
	{
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
	}
}
