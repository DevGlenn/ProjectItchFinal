using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask hitLayer;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null) {
            enemy.TakeHit();
        }
        Debug.Log(collision.collider.name);
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
