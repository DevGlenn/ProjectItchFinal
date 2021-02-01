using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingDragon : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
	[SerializeField] private float distance;
	public GameObject player;
	private bool enemyIsDead = false;

	[SerializeField] private Vector2 firstPos; //start positie
	[SerializeField] private Vector2 secondPos; //eind positie
	private Vector2 currentPos; //de positie waar het object zich nu bevindt


	public bool MoveRight = true;
	public Transform groundDetection;

	public Animator animator;

    private void Start()
    {
		transform.position = currentPos;
	}
    void Update()
	{
		transform.position = Vector3.Lerp(firstPos, secondPos, Mathf.PingPong(Time.time * enemySpeed, 1.0f));
        if (firstPos == currentPos)
        {
            
           // transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-2, 2, 1));
        }
        else if (secondPos == currentPos)
        {
			//transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-2, 2, 1));
		}

    }

    public void TakeHit()
	{
		Die();
	}
	private void Die()
	{
		//  Destroy(gameObject);
		enemyIsDead = true;
		
		if (gameObject.tag == "WalkingEnemy")
		{
			Debug.Log(gameObject.tag);
			
			animator.SetBool("IsDead", true);		//speel de animatie af
															    
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
