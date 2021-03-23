using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class EnemyForward : MonoBehaviour
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
    public float cooldownTime3Shoot= 2;
    private float nextShoot3Time = 0;
   
    public float cooldownTimeShoot= 2;
    private float nextShootTime = 0;
    private float countShoot = 0;
    public bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector2(transform.position.x, (transform.position.y-2));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =new Vector2(transform.position.x ,transform.position.y -speed *Time.deltaTime);
        if (Time.time > nextShootTime)
        {
            
            
            if (canShoot)
            {
                if (Time.time > nextShoot3Time)
                {
            
                    InstanceBullet();
  
                }
            }
            else
            {
                nextShootTime = Time.time + cooldownTimeShoot;
                countShoot = 0;
                canShoot = true;
            }
            
        }
        
        
         
    }

    void InstanceBullet()
    {
        if (countShoot < 3)
        {
            Instantiate(bullet, shootPoint.position, Quaternion.identity);
            countShoot++;
            nextShoot3Time = Time.time + cooldownTime3Shoot;
        }
        else
        {
            canShoot = false;
        }
           


    }
}
