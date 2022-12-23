using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inmortal : UnitHealth
{
    // Start is called before the first frame update
    void Start()
    {
        unitHealth = 100;
    }

     public override void Damage(int damage)
    {
        unitHealth -= damage;
    }
    public override int GetCurrentHealth()
    {
        if (unitHealth <= 0)
        {
            unitHealth = 1;
        }
        return unitHealth;
    }
}
