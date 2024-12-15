using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrototype
{
    private GameObject bulletPrefab;

    public BulletPrototype(GameObject bulletPrefab)
    {
        this.bulletPrefab = bulletPrefab;
    }

    public GameObject Clone()
    {
        return Object.Instantiate(bulletPrefab);
    }
}
