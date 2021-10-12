using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Money_TileMap : MonoBehaviour
{
	public Tilemap money_tilemap;
	
	public int worth = 100;
	public GameObject moneyEffect;
	public GameObject coin_sound;

    void Start()
    {
        money_tilemap = GetComponent<Tilemap>();
    }

    void Update()
    {
        
    }
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			Vector3 hitPosition = Vector3.one;
			foreach(ContactPoint2D hit in collision.contacts)
			{
				hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
				hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
				money_tilemap.SetTile(money_tilemap.WorldToCell(hitPosition), null);
				
				LevelManager.instance.IncreaseCurrency(worth);
				Instantiate(coin_sound, transform.position, transform.rotation);
			}
		}
	}
}
