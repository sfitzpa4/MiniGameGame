﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject UIPanel;
	public GameObject loadingImage;

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
		Time.timeScale = 1;
		scene = 0;
		//loadingImage.SetActive(true);
		SceneManager.LoadScene(0);
	}
}
