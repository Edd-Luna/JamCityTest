using UnityEngine;

public abstract class UnitHealth : MonoBehaviour
{
    public int unitHealth;

    void Update () 
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
    public abstract void Damage(int damage);
    public abstract int GetCurrentHealth();
}