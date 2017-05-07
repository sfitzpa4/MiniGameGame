using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PongPauseMenu : MonoBehaviour {

	public GameObject UIPanel;
	public GameObject HighScorePanel;
	public GameObject loadingImage;
	public GameObject networkManager;

	// Use this for initialization
	public void Confirm () {
		UIPanel.SetActive(false);
		Time.timeScale = 1;
	}

	// Update is called once per frame
	public void ResumeButton () {
		Confirm();
	}

	public void PauseButton ()
	{
		Time.timeScale = 0;
		UIPanel.SetActive (true);
	}

	public void LoadScene(int scene)
	{
		networkManager.SetActive (false);
		Time.timeScale = 1;
		scene = 0;
		//loadingImage.SetActive(true);
		SceneManager.LoadScene(0);
	}

	public void ScoreButton ()
	{
		Time.timeScale = 0;
		UIPanel.SetActive(false);
		HighScorePanel.SetActive(true);
	}

	public void ReturnButton()
	{
		HighScorePanel.SetActive(false);
		UIPanel.SetActive(true);
	}
}
