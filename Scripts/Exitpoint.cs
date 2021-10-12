using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exitpoint : MonoBehaviour
{
	public string nextArea;
	
	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			SceneManager.LoadScene(nextArea);
		}
	}
}
