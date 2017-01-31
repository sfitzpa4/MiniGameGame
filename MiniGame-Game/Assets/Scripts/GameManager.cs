using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public Text livesText;
	
	public GameObject gameOver;
	public GameObject winner;
	public GameObject brickParticle;
	public GameObject paddle;
	public GameObject bricksModel;
	
	public static GameManager instance = null;
	
	private GameObject clonePaddle;
	
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy(gameObject);
		}
		Setup();
	}
	
	// Update is called once per frame
	void Setup () {
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate(bricksModel, transform.position, Quaternion.identity);
	}
	
	void CheckGameOver() {
	
		if (bricks < 1)
		{
			winner.SetActive(true);
			Time.timeScale = 0.25f;
			Invoke("Reset", resetDelay);
		}
		
		if (lives < 1) 
		{
			gameOver.SetActive(true);
			Time.timeScale = 0.25f;
			Invoke("Reset", resetDelay);
		}
	}
	
	void Reset() {
		Time.timeScale = 1f;
		// Return to first level (could be changed for new levels)
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
	
	public void LoseLife() 
	{
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate(brickParticle, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver();
	}
	
	void SetupPaddle() 
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}
	
	public void DestroyBrick()
	{
		bricks--;
		CheckGameOver();
	}
}
