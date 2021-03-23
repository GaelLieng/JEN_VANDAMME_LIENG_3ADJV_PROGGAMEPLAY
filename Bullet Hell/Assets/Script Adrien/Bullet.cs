using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDirection;

    private float moveSpeed;
    public float attack = 25f;
    private void OnEnable()
    {
        Invoke(nameof(Destroy),3f);
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed *Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    /*
       private void Destroy()
    {
        Destroy(gameObject);
    }
     */

    private void OnDestroy()
    {
        CancelInvoke();
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if an object with the tag "Player" enter the box collider, inflicts damage to player's life point and destroy the bullet
        
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().TakeDmg(attack);
            Debug.Log("-25hp");
            Destroy();  
        }
        
        //if an object with the tag Wall enter the box collider, destroy the bullet
   
    }
}
