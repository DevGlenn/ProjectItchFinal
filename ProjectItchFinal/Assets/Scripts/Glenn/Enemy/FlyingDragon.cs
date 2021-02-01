using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDragon : MonoBehaviour
{
	[SerializeField] private float enemySpeed;
	public GameObject player;

	public bool MoveRight;

	public Animator animator;
	void Update()
	{
		// Use this for initialization
		if (MoveRight)
		{
			transform.Translate(2 * Time.deltaTime * enemySpeed, 0, 0);
			transform.localScale = new Vector2(-2, 2);
		}
		else
		{
			transform.Translate(-2 * Time.deltaTime * enemySpeed, 0, 0);
			transform.localScale = new Vector2(2, 2);
		}
	}
	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Blockades"))
		{

			if (MoveRight)
			{
				MoveRight = false;
			}
			else
			{
				MoveRight = true;
			}
		}
	}

	public void TakeHit()
	{
		Die();
	}
	private void Die()
	{
		//  Destroy(gameObject);


		if (gameObject.tag == "FlyingEnemy")
		{
			Debug.Log(gameObject.tag);
			
			animator.SetBool("IsDead", true);                   //speel de animatie af

		}
		Debug.Log(gameObject.tag);
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		PlayerMovement player = collision.collider.GetComponent<PlayerMovement>(); //de player = zijn eigen collider en dan get hij het script PlayerMovement
		if (player != null && collision.collider == player.PlayerCollider) //als de player bestaat en de collision de player collider is
		{
			Debug.Log(collision.collider);
			player.TakeDamage(); //doe de TakeDamage functie van het player script
		}
	}
}
