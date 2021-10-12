using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public float movementSpeed;
	public Rigidbody2D rb;
	public GameObject jump_sound;
	
	public Animator anim;
	
	public float jumpForce = 20f;
	public Transform feet;
	public LayerMask groundLayers;
	
	[HideInInspector] public bool isFacingRight = true;
	
	float mx;
	
	public static bool gameIsPaused;
	public GameObject pausemenu;
	
	public bool flashActive;
	public float flashLength;
	public float flashCounter;
	
	public SpriteRenderer playerSprite;
	
	void Start()
	{
		pausemenu = GameObject.Find("PauseMenu");
		pausemenu.gameObject.SetActive(false);
		
		playerSprite = GetComponent<SpriteRenderer>();
		flashActive = true;
	}
	
	void Update()
	{
		mx = Input.GetAxisRaw("Horizontal");
		
		if (Input.GetButtonDown("Jump") && IsGrounded())
		{
			Jump();
		}
		
		if (Mathf.Abs(mx) > 0.05f)
		{
			anim.SetBool("isRunning", true);
		} else
		{
			anim.SetBool("isRunning", false);
		}
		
		// Truning around
		if (mx > 0f)
		{
			transform.localScale = new Vector3(1f, 1f, 1f);
			isFacingRight = true;
		}
		else if (mx < 0f)
		{
			transform.localScale = new Vector3(-1f, 1f, 1f);
			isFacingRight = false;
		}
	
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			gameIsPaused = !gameIsPaused;
			PauseGame();
		}
		
		anim.SetBool("isGrounded", IsGrounded());
		
		if(flashActive)
		{
			if(flashCounter > flashLength * .66f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			} 
			else if(flashCounter > flashLength * .33f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
			} 
			else if(flashCounter > 0f)
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
			}
			else
			{
				playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
				flashActive = false;
			}
			
			flashCounter -= Time.deltaTime;
		}
		
	}
	
	private void FixedUpdate()
	{
		Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
		
		rb.velocity = movement;
	}
	
	void Jump()
	{
		Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
		rb.velocity = movement;
		Instantiate(jump_sound, transform.position, transform.rotation);
	}
	
	public bool IsGrounded()
	{
		Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);
		
		if (groundCheck != null)
		{
			return true;
		}
		
		return false;
	}
	
	void PauseGame()
	{
		if(gameIsPaused)
		{
			Time.timeScale = 0f;
			pausemenu.gameObject.SetActive(true);
		}
		else
		{
			Time.timeScale = 1;
			pausemenu.gameObject.SetActive(false);
		}
	}	
}