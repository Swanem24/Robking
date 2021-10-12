using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("DeathFloor") || collision.gameObject.CompareTag("Ground"))
		{
			Destroy(gameObject, 1);
		}
	}
}
