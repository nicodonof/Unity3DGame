﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void NewGame(){
		SceneManager.LoadScene("Matuteale", LoadSceneMode.Single);
	}

	public void QuitGame(){
		Application.Quit();
	}
}
