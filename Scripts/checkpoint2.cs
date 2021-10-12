using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint2 : MonoBehaviour
{
	public string currentStage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			LevelManager.instance.checkpoint(currentStage);
		}
	}
}
