using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector2 moveInput;
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
    }

    void FixedUpdate()
    {
        myRigidbody.velocity = moveVelocity;
    }
    
}
