using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControl : MonoBehaviour
{
	public Button m_resumeButton, m_exitButton;
	public static bool gameIsPaused;
	public GameObject pauseMenu;
	
	void Start()
	{
		m_resumeButton.onClick.AddListener(PauseGame);
		m_exitButton.onClick.AddListener(ExitGame);
	}
	
	void update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			gameIsPaused = !gameIsPaused;
			PauseGame();
		}
	}
	
	void PauseGame()
	{
		if(gameIsPaused)
		{
			Time.timeScale = 0f;
			pauseMenu.gameObject.SetActive(true);
		}
		else
		{
			Time.timeScale = 1;
			pauseMenu.gameObject.SetActive(false);
		}
	}
	
	void ExitGame()
	{
		Application.Quit();
		Debug.Log("Quit");
	}
}
