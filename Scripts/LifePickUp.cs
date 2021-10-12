using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickUp : MonoBehaviour
{
	public int lifeworth = 1;
	public GameObject lifeEffect;
	public GameObject sound;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			Destroy(gameObject);
			LevelManager.instance.IncreaseLife(lifeworth);
			Instantiate(lifeEffect, transform.position, transform.rotation);
			Instantiate(sound, transform.position, transform.rotation);
		}
	}
}
