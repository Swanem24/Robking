using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDeath : MonoBehaviour
{
	public GameObject player_hit_sound;
	public GameObject player_fall_to_death_sound;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Instantiate(player_hit_sound, transform.position, transform.rotation);
			Destroy(gameObject);
			LevelManager.instance.Respawn();
		}
		else if (collision.gameObject.CompareTag("DeathFloor"))
		{
			Instantiate(player_fall_to_death_sound, transform.position, transform.rotation);
			Destroy(gameObject);
			LevelManager.instance.Respawn();
		}
	}
}
