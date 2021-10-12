using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyPickUp : MonoBehaviour
{
	public int worth = 100;
	public GameObject moneyEffect;
	public GameObject coin_sound;
	
	void Start()
	{
	
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Destroy(gameObject);
			LevelManager.instance.IncreaseCurrency(worth);
			Instantiate(moneyEffect, transform.position, transform.rotation);
			Instantiate(coin_sound, transform.position, transform.rotation);
		}
	}
}
