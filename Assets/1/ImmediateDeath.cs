using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmediateDeath : MonoBehaviour
{
    private UnitHealth unitHealtScrpit;
    // Start is called before the first frame update
    void Start()
    {
        unitHealtScrpit = gameObject.GetComponent<UnitHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if( unitHealtScrpit.unitHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
