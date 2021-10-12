using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
	public static LevelManager instance;

	[Header("Currency")]
	public int currency = 0;
	public Text currencyUI;
	
	public int lifechance = 3;
	public Text life;
	private int currentlife;
	
	public Text result;
	
	public Transform currentrespawnPoint;
	public Transform respawnPoint;
	public Transform respawnPoint2;
	public Transform respawnPoint3;
	public Transform respawnPoint4;
	public Transform respawnPoint5;
	public Transform respawnPoint6;
	public GameObject playerPrefab;
	
	public CinemachineVirtualCameraBase cam;
	
	public GameObject gameOver;
	
	public GameObject pause_menu;
	
	private static bool managerExists;
	
	public void Awake()
	{
		instance = this;
		life.text = "X " + lifechance;
		currentlife = lifechance;
		currency = 0;
		currencyUI.text = "$0";
		gameOver.gameObject.SetActive(false);
		
		//if(!managerExists)
		//{
			//managerExists = true;
			//DontDestroyOnLoad(transform.gameObject);
		//}
		//else
		//{
			//Destroy(gameObject);
		//}
		
	}
	
	void Update()
	{
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName ("End")) 
         {
		 	PrintResult();
			DontDestroyOnLoad(transform.gameObject);
         }
	}
	
	public void checkpoint(string respawnPoint)
	{
		if(respawnPoint == "Stage 2")
		{
			currentrespawnPoint = respawnPoint2;
		}
		else if(respawnPoint == "Stage 3")
		{
			currentrespawnPoint = respawnPoint3;
		}
		else if(respawnPoint == "Stage 4")
		{
			currentrespawnPoint = respawnPoint4;
		}
		else if(respawnPoint == "Stage 5")
		{
			currentrespawnPoint = respawnPoint5;
		}
		else if(respawnPoint == "Stage 6")
		{
			currentrespawnPoint = respawnPoint6;
		}

	}
	
	public void IncreaseCurrency(int amount)
	{
		currency += amount;
		currencyUI.text = "$: " + currency; 
	}
	
	public void IncreaseLife(int amount)
	{
		currentlife += amount;
		life.text = "X " + currentlife;
	}
	
	public void Respawn()
	{
		currentlife -= 1;
		life.text = "X " + currentlife;
		
		pause_menu.gameObject.SetActive(true);
		
		if(currentlife <= 0)
		{
			gameOver.gameObject.SetActive(true);
			pause_menu.gameObject.SetActive(false);
		}
		else
		{
			GameObject player = Instantiate(playerPrefab, currentrespawnPoint.position, Quaternion.identity);
			cam.Follow = player.transform;	
		}
	}
	
	public void PrintResult()
	{
		if(currency > 0 && currency < 10000)
		{
			result.text = "You are terrible at this!";
		}
		else if (currency > 10000 && currency < 100000)
		{
			result.text = "This is not enough to not work for a lifetime";
		}
		else if (currency > 100000)
		{
			result.text = "You got skills";
		}
		else if (currency == 1000000)
		{
			result.text = "You did it!! You actually stole a million dollar.";
		}
	}
}
