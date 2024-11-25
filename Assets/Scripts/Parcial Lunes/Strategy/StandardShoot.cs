using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardShootingStrategy : IShootingStrategy
{
    public void Shoot(GameObject bulletPrefab, Transform shooter, Transform target)
    {
        Object.Instantiate(bulletPrefab, shooter.position, Quaternion.identity);
    }
}
