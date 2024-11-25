using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootingStrategy
{
    void Shoot(GameObject bulletPrefab, Transform shooter, Transform target);
}
