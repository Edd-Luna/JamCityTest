using UnityEngine;

public abstract class UnitHealth : MonoBehaviour
{
    public int unitHealth;
    //public int currentHealth;
    public abstract void Damage(int damage);
    public abstract int GetCurrentHealth();
}