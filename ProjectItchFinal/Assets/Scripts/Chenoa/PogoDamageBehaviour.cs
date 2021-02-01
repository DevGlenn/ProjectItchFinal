using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PogoDamageBehaviour : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision) {
        WalkingDragon walkingDragon = collision.collider.GetComponent<WalkingDragon>();
        if (walkingDragon != null) 
        {
            
            walkingDragon.TakeHit();
        }
        
        FlyingDragon flyingDragon = collision.collider.GetComponent<FlyingDragon>();
        if (flyingDragon != null)
        {

            flyingDragon.TakeHit();
        }
        
    }
}
