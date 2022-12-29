using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaledDeath : MonoBehaviour
{
    private UnitHealth unitHealtScrpit;
    private Vector3 scaleChange = new Vector3(0.2f, 0.2f, 0.2f);
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
            transform.localScale -= (scaleChange * Time.deltaTime);
            if (transform.localScale.x <=  0.4f)
            {
                Destroy(gameObject);
            }
        }
    }
}