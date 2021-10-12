using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject platform_tile;
	
	public float waitTime;
	private float waitCounter;
	
	private bool isSpawning;

    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
		if(isSpawning)
		{
			waitCounter -= Time.deltaTime;
			
			if(waitCounter < 0)
			{
				isSpawning = false;
				waitCounter = waitTime;
				spawnPlatform();
			}
		}
		else
		{
			isSpawning = true;
		}
    }
	
	public void spawnPlatform()
	{
		Instantiate(platform_tile, new Vector3(Random.Range(29, 110), -57, 0), transform.rotation);
	}
}
