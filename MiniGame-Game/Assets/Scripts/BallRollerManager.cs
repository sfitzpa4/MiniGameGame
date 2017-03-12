using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallRollerManager : MonoBehaviour {


    public int lives = 3;
    public int numCapsules = 4;
    public Text livesText;

    public GameObject gameOver;
    public GameObject winner;

    public float resetDelay = 1f;

    public GameObject ball;
    public GameObject capsules;

    public static BallRollerManager instance = null;

    private GameObject cloneBall;
    private GameObject cloneCapsules;

    public GameObject UIPanel;
    private bool gameStart = false;

    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
    }

    private void Update()
    {
        if (UIPanel.activeSelf == false && gameStart == false)
        {
            Setup();
            gameStart = true;
        }
    }
    

    // Update is called once per frame
    void Setup () {
        
        cloneBall = Instantiate(ball, transform.position, Quaternion.identity) as GameObject;
        cloneCapsules = Instantiate(capsules, transform.position, Quaternion.identity) as GameObject;
        //Instantiate(capsules, transform.position, Quaternion.identity);
        
    }

    void Reset()
    {
        Time.timeScale = 1f;
        // Return to first level (could be changed for new levels)
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void CheckGameOver()
    {

        if (numCapsules < 1)
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

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        //Instantiate(brickParticle, clonePaddle.transform.position, Quaternion.identity);
        Destroy(cloneBall);
        Invoke("SetupBall", resetDelay);
        CheckGameOver();
    }

    void SetupBall ()
    {
        cloneBall = Instantiate(ball, transform.position, Quaternion.identity) as GameObject;
    }

    public void getCapsule()
    {
        numCapsules--;
        CheckGameOver();
    }
}

