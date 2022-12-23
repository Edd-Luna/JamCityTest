using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReducedDamage : UnitHealth
{
    // Start is called before the first frame update
    void Start()
    {
        unitHealth = 100;
    }

     public override void Damage(int damage)
    {
        unitHealth -=  (60*damage)/100; 
    }
    public override int GetCurrentHealth()
    {
        return unitHealth;
    }
}
