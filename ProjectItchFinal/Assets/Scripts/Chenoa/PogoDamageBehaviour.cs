using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoDamageBehaviour : MonoBehaviour
{
	public void OnCollisionEnter2D(Collision2D collision) {
        WalkingDragon walkingDragon = collision.collider.GetComponent<WalkingDragon>();
        if (walkingDragon != null) 
        {
            if(collision.collider.CompareTag("WalkingEnemy"))
            {
                walkingDragon.TakeHit();
            }
            
        }
        
        FlyingDragon flyingDragon = collision.collider.GetComponent<FlyingDragon>();
        if (flyingDragon != null)
        {
            if (collision.collider.CompareTag("FlyingEnemy"))
            {
                flyingDragon.TakeHit();
            }
        }
    }
}
