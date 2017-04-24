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
    public GameObject capsulesLvl1;
    public GameObject capsulesLvl2;
    public GameObject hazardsLvl1;
    public GameObject hazardsLvl2;

    public static BallRollerManager instance = null;

    private GameObject cloneBall;
    private GameObject cloneCapsules;
    private GameObject cloneHazards;

    public GameObject UIPanel;

    private int level = 1;
    

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
        Time.timeScale = 0;
        if (UIPanel.activeSelf == false)
        {
            Setup();
        }


    }

    private void Update()
    {
       
    }
    

    // Update is called once per frame
    void Setup () {
        
        cloneBall = Instantiate(ball, transform.position, Quaternion.identity) as GameObject;
        cloneCapsules = Instantiate(capsulesLvl1, transform.position, Quaternion.identity) as GameObject;
        cloneHazards = Instantiate(hazardsLvl1, transform.position, Quaternion.identity) as GameObject;
        //Instantiate(capsules, transform.position, Quaternion.identity);
        
    }

    void Reset()
    {
        Time.timeScale = 1f;
        // Return to first level (could be changed for new levels)
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void NextLevel()
    {
        if (level == 2)
        {
            Debug.Log("Advancing to next level");
            Destroy(cloneBall);
            Invoke("SetupBall", resetDelay);
            //cloneBall = Instantiate(ball, transform.position, Quaternion.identity) as GameObject;
            cloneCapsules = Instantiate(capsulesLvl2, transform.position, Quaternion.identity) as GameObject;
            Destroy(cloneHazards);
            cloneHazards = Instantiate(hazardsLvl2, transform.position, Quaternion.identity) as GameObject;
        }
    }

    void CheckGameOver()
    {

        if (numCapsules < 1)
        {
            if (level == 1)
            {
                numCapsules = 4;
                Invoke("NextLevel", resetDelay);
                level++;
            }
            if (level == 3)
            {
                winner.SetActive(true);
                Time.timeScale = 0.25f;
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

