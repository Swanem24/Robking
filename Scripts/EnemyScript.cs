using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
	public float speed = 2f;
	public Rigidbody2D rb;
	public LayerMask groundLayers;
	public LayerMask playerLayer;
	
	public Transform groundCheck;
	public Transform firingPoint;
	
	bool isFacingRight = true;
	
	RaycastHit2D hit;
	RaycastHit2D hitPlayer;
	
	private void Update()
	{
		hit = Physics2D.Raycast(groundCheck.position, - transform.up, 1f, groundLayers);
		hitPlayer = Physics2D.Raycast(firingPoint.position, transform.right, -4f, playerLayer);
		hitPlayer = Physics2D.Raycast(firingPoint.position, - transform.right, -4f, playerLayer);
	}
	
	private void FixedUpdate()
	{
		
							
		if (hitPlayer.collider != false)
		{
			rb.velocity = new Vector2(0, 0);
		}
		else
		{
			Patrol();
		}
	}
	
	public void Patrol()
	{
		if (hit.collider != false)
		{
			if (isFacingRight)
			{
				rb.velocity = new Vector2(speed, rb.velocity.y);
			} 
			else
			{
				rb.velocity = new Vector2(-speed, rb.velocity.y);
			}
		}
		else
		{
			isFacingRight = !isFacingRight;
			transform.localScale = new Vector3(-transform.localScale.x, 1f, 1f);
		}
	}
}
