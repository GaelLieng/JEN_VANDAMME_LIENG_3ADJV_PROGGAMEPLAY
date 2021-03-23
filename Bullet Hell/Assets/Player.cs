using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject a, b;
    public GameObject Projectile;
    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    private int health = 3;

    private Vector2 moveInput;
    private Vector2 moveVelocity;

    private int delay = 0;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
        b = transform.Find("b").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        if (Input.GetKey(KeyCode.Space) && delay>30)
        {
            Shoot();
        }

        delay++;
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

    void Shoot()
    {
        delay = 0;
        
        Instantiate(Projectile, a.transform.position, Quaternion.identity);
        Instantiate(Projectile, b.transform.position, Quaternion.identity);
    }
    
}
