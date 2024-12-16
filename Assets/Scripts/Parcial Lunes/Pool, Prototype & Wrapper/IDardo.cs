using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDardo
{
    void Initialize(GameObject target, Aim aim);
    void OnHitTarget();
}
