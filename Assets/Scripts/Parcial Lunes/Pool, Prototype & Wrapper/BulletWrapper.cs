using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWrapper : IDardo
{
    private IDardo baseBullet;
    private static int bulletsFired;
    private static int bulletsHit;

    public BulletWrapper(IDardo baseBullet)
    {
        this.baseBullet = baseBullet;
        bulletsFired++;
        Debug.Log($"Balas disparadas: {bulletsFired}");
    }

    public void Initialize(GameObject target, Aim aim)
    {
        baseBullet.Initialize(target, aim);
    }

    public void OnHitTarget()
    {
        bulletsHit++;
        Debug.Log($"Balas que impactaron: {bulletsHit}");
        baseBullet.OnHitTarget();
    }
}
    
