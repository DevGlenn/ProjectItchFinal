using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDragon : MonoBehaviour
{
	[SerializeField] private float enemySpeed;
	[SerializeField] private float distance;
	public GameObject player;
	private bool enemyIsDead = false;
	[SerializeField] private float timer = 3f;
	[SerializeField] private Vector2 firstPos; //start positie
	[SerializeField] private Vector2 secondPos; //eind positie
	private Vector2 currentPos; //de positie waar het object zich nu bevindt

	public Animator animator;

	private void Start()
	{

	}
	void Update()
	{
		if (timer <= 0f)
		{
			Destroy(gameObject);
		}
		if (enemyIsDead == true)
		{
			timer -= Time.deltaTime;
		}
		currentPos = transform.position;
		if (!enemyIsDead)
		{
			transform.position = Vector3.Lerp(firstPos, secondPos, Mathf.PingPong(Time.time * enemySpeed, 1.0f));
			currentPos = transform.position;
		}

		if (!enemyIsDead)
		{
			transform.position = Vector3.Lerp(firstPos, secondPos, Mathf.PingPong(Time.time * enemySpeed, 1.0f));
		}
	}

	public void TakeHit()
	{
		Die();
	}
	public void Die()
	{

		//  Destroy(gameObject);


		enemyIsDead = true;
		Debug.Log(gameObject.tag);

		animator.SetBool("IsDead", true);       //speel de animatie af


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
