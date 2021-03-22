using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    // Start is called before the first frame update
    public static BulletPool bulletPoolInstance;

    [SerializeField] 
    private GameObject poolBullet;

    private bool notenoughtBulletInPool = true;

    private List<GameObject> bullets;

    private void Awake()
    {
        bulletPoolInstance = this;
    }

    void Start()
    {
        bullets = new List<GameObject>();
    }

    // Update is called once per frame
    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notenoughtBulletInPool)
        {
            GameObject bul = Instantiate(poolBullet);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }
}
