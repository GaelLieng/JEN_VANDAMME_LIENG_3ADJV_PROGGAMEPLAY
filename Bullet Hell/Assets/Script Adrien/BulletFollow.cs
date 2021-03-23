using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollow : MonoBehaviour
{
    [Header("Speed")]
    public float speed;
    
    [Header("Damage")]
    public float attack = 25f;
    
    private Transform player;
    private Vector3 MoveDirection;
    private Rigidbody2D rb;
    
    // ------ Functions ----------
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        
        //Move the bullet to the last player position
        MoveDirection = (player.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(MoveDirection.x, MoveDirection.y);
            
        //Destroy the bullet in 6seconds;
        Destroy(gameObject,6f);
    }

    void Update()
    {
        
        
       
    }
    
    //Destroy the bullet
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if an object with the tag "Player" enter the box collider, inflicts damage to player's life point and destroy the bullet
        
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().TakeDmg(attack);
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
