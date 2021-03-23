using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private int dir = 1;
    
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
}
