using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyLife : MonoBehaviour
{
    // ------ Variables ----------
    [Header("Health")]
    public float maxHealth;
    public float health;
    void Start()
    {
        //life is equal to the maximum life
        health = maxHealth;
    }

    // ------ Functions ----------
    void Update()
    {
        //if health is superior to maxHealth, health is equal to maxHealth 
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        
        //if health is equal to zero destroy the gameobject
        if (health <= 0f)
        {
            health = 0f; 
            
            Destroy(gameObject);
            
        }
    }

    public void HurtEnemy(float dmg)
    {
        health -= dmg;
    }

}
