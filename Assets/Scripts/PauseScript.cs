using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

	private GameObject PausePanel;
	public GameObject GameEndedPanel;

	// Use this for initialization
	void Start () {
		PausePanel = GameObject.Find("PausePanel");
		PausePanel.SetActive(false);
		GameEndedPanel = GameObject.Find("GameEndedPanel");
		GameEndedPanel.SetActive(false);
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
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}

	public void RestartGame(){
		Time.timeScale = 1;
		SceneManager.LoadScene("Matuteale", LoadSceneMode.Single);
	}

	public void ShowGameEndedPanel(string winnerText){
		Time.timeScale = 0;
		GameEndedPanel.SetActive(true);
		GameObject.Find("EndGameText").GetComponent<Text>().text = winnerText;
	}
}
