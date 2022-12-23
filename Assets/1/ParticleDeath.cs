using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeath : MonoBehaviour
{
    private UnitHealth unitHealtScrpit;
    public ParticleSystem deathParticle;
    
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
            Instantiate(deathParticle, transform.position, deathParticle.transform.rotation);
            Destroy(gameObject);
        }
    }
}
