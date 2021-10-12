using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public Transform firingPoint;
	public GameObject bulletPrefab;
	public GameObject target;
	
	public LayerMask playerLayer;
	
	public float waitTime;
	private float waitCounter;
	
	private static bool shooting;
	
	RaycastHit2D hitRight;
	RaycastHit2D hitLeft;
	
	void Start()
	{
		waitCounter = waitTime;
		//target = GameObject.Find("Player");
		target = GameObject.FindWithTag("Player");
		
	}
	
	void Update()
	{
		hitRight = Physics2D.Raycast(firingPoint.position, transform.right, 4f, playerLayer);
		hitLeft = Physics2D.Raycast(firingPoint.position, transform.right, -4f, playerLayer);
	
		if(shooting)
		{
			waitCounter -= Time.deltaTime;
			
			if (waitCounter < 0)
			{
				{
					if(hitRight.collider != false || hitLeft.collider != false)
					{
						Shoot();
						shooting = false;
					}
				}
			}
			else
			{
				target = GameObject.FindWithTag("Player");
			}
		}
		else
		{
			shooting = true;
			target = GameObject.FindWithTag("Player");
		}
	}
	
	void Shoot()
	{
		Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
		waitCounter = waitTime;
	}
}
