using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public Button m_playButton, m_exitButton;
	public Animator transition;
	
	void Start()
	{
		m_playButton.onClick.AddListener(PlayGame);
		m_exitButton.onClick.AddListener(ExitGame);
	}
	
	void update()
	{
		//
	}
	
	public void PlayGame()
	{
		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
	}
	
	IEnumerator LoadLevel(int levelIndex)
	{
		//transition.SetBool("Start", true);
			
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(2);
		
		SceneManager.LoadScene(levelIndex);
	}
	
	void ExitGame()
	{
		transition.SetTrigger("Start");
		Application.Quit();
		Debug.Log("Quit");
	}
}
