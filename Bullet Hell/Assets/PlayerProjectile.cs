using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private int dir = 1;
    public float attack = 25f;
    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    public void ChangeDirection()
    {
        dir *= -1;
    }
    
    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(0, 6*dir);
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if an object with the tag "Player" enter the box collider, inflicts damage to player's life point and destroy the bullet
        
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyLife>().HurtEnemy(attack);
            Debug.Log("-25hp");
            DestroyBullet();  
        }
        
        //if an object with the tag Wall enter the box collider, destroy the bullet
        if (other.CompareTag("Wall"))
        {
            DestroyBullet();  
        }
    }
}
