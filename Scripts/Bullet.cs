using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float bulletSpeed = 1f;
	public Rigidbody2D rb;
	
	public GameObject target;
	Vector2 moveDirection;
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindWithTag("Player");
		moveDirection = (target.transform.position - transform.position).normalized * bulletSpeed; 
	}
	
	private void FixedUpdate()
	{
		rb.velocity = new Vector2 (moveDirection.x, 0);
		//rb.velocity = target.transform.position * bulletSpeed;
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		Destroy(gameObject);
	}
}
