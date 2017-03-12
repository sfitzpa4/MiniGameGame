using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallRollMenu : MonoBehaviour {

    public GameObject UIPanel;
    public GameObject loadingImage;

    // Use this for initialization
    public void Confirm () {
        UIPanel.SetActive(false);
  
	}
	
	// Update is called once per frame
	public void StartButton () {
        Confirm();
	}

    

    public void LoadScene(int scene)
    {
        scene = 0;
        //loadingImage.SetActive(true);
        SceneManager.LoadScene(0);
    }
}
