using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject a, b;
    public GameObject Projectile;
    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    public float health ;
    public float maxHealth = 100f;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    public float cooldownTimeShoot= 0.1f;
    private float nextShootTime = 0;
    private int delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
        b = transform.Find("b").gameObject;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        if (Time.time > nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + cooldownTimeShoot;
        }

        delay++;
        
        if (health <= 0)
        {
            health = 0f;
            
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }

    public void Damage()
    {
        health--;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
    
    public void TakeDmg(float dmg)
    {
        health -= dmg;
    }

    void Shoot()
    {
        delay = 0;
        
        Instantiate(Projectile, a.transform.position, Quaternion.identity);
        Instantiate(Projectile, b.transform.position, Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if an object with the tag "Player" enter the box collider, inflicts damage to player's life point and destroy the bullet
        
        if (other.CompareTag("Enemy"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        
    
    }
}
