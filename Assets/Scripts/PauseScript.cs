using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	private GameObject PausePanel;

	// Use this for initialization
	void Start () {
		PausePanel = GameObject.Find("PausePanel");
		PausePanel.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Escape)) {
			if (Time.timeScale == 1) {
				PauseGame();
			}else{
				ResumeGame();
			}
		}
	}
	private void PauseGame(){
		Time.timeScale = 0;
		PausePanel.SetActive(true);
	}
	public void ResumeGame(){
		Time.timeScale = 1;
		PausePanel.SetActive(false);
	}

	public void MainMenu(){
		Time.timeScale = 1;
		PausePanel.SetActive(false);
	}
}
