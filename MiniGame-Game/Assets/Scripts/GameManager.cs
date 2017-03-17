using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
    public int brickslvl2 = 22;
	public float resetDelay = 1f;
    private int score = 0;
	public Text livesText;
    public Text scoreText;
	
	public GameObject gameOver;
	public GameObject winner;
	//public GameObject brickParticle;
	public GameObject paddle;
	public GameObject bricksLevel1;
    public GameObject bricksLevel2;
	
	public static GameManager instance = null;
	
	private GameObject clonePaddle;
    private int level = 1;
	
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
		Instantiate(bricksLevel1, transform.position, Quaternion.identity);
	}

    void NextLevel()
    {
        if (level == 2)
        {
            Debug.Log("Advancing to next level");
            bricks = brickslvl2;
            Instantiate(bricksLevel2, transform.position, Quaternion.identity);
        }
    }
	
	void CheckGameOver() {
	
		if (bricks < 1)
		{
			
			//Time.timeScale = 0.25f;
            if (level == 1)
            {
                Invoke("NextLevel", resetDelay);
                level++;
            }
            if (level == 3)
            {
                winner.SetActive(true);
                Invoke("Reset", resetDelay);
            }
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
		//Instantiate(brickParticle, clonePaddle.transform.position, Quaternion.identity);
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
        score += 100;
        scoreText.text = "Score: " + score;
        CheckGameOver();
	}
}
