using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBaseEnemy : MonoBehaviour
{
    [Header("Speed")]
    public float speed;

    
    [Header("Distance")]
    public float stopDistance;
    
    [Header("Time between each bullet")]
    public float startTimeBetweenShot;
    
    [Header("Shoot")]
    public GameObject bullet;
    public Transform shootPoint;

    [Header("Damage")] 
    public float attack = 25f;

    public float cooldownTimeShoot= 2;
    private float nextShootTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =new Vector2(transform.position.x ,transform.position.y -speed *Time.deltaTime);
        if (Time.time > nextShootTime)
        {
            InstanceBullet();
            nextShootTime = Time.time + cooldownTimeShoot;
        }
        
            
    }
        
        
         
    

    void InstanceBullet()
    {
        Instantiate(bullet, shootPoint.position, Quaternion.identity);

    }
}
