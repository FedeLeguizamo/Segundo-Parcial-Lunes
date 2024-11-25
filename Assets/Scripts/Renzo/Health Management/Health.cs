using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHP;
    public float dmgTaken;
    private float HP;
    public bool isInvincible = false;

    void Start()
    {
        HP = maxHP;
    }
    
    void FixedUpdate()
    {
        // Solo aplicar daño si no es invencible
        if (!isInvincible)
        {
            maxHP -= dmgTaken;
        }
        dmgTaken = 0; // Reseteamos el daño acumulado

        if (maxHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
