using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidShootingStrategy : IShootingStrategy
{
    public void Shoot(GameObject bulletPrefab, Transform shooter, Transform target)
    {
        Debug.Log($"{shooter.name} dispara rápidamente.");
        for (int i = 0; i < 3; i++) 
        {
            Vector3 offset = new Vector3(0, 0.2f * i, 0); 
            Object.Instantiate(bulletPrefab, shooter.position + offset, Quaternion.identity);
        }
    }
}
