using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpiralShoot : MonoBehaviour
{
    private float angle = 0f;
    private Vector2 bulletMoveDirection;
    void Start()
    {
        InvokeRepeating("Fire", 0f,0.1f);
    }

    private void Fire()
    {
        for (int i = 0; i <= 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180);
            
            Vector3 bulMoveVector = new Vector3(bulDirX,bulDirY,0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
        }

        angle += 10f;
        if (angle >= 360f)
        {
            angle = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
