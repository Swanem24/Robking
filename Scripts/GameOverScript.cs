using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
	public Button m_retryButton, m_exitButton;
	
	void Start()
	{
		m_retryButton.onClick.AddListener(Retry);
		m_exitButton.onClick.AddListener(ExitGame);
	}
	
	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		LevelManager.instance.Awake();
	}
	
	void ExitGame()
	{
		Application.Quit();
		Debug.Log("Quit");
	}
}
