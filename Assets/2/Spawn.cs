using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject ball;
    //private float spawnRangeX = 4.5f;
    //private float spawnRangeY = 4.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   /*
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Instantiate(ball, hit.point, Quaternion.identity);
            }
        }*/
    }

    private void OnMouseDown() 
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        Debug.Log(mousePos.x);
        Debug.Log(mousePos.y);
        Vector3 spawnPos = Camera.main.ScreenToWorldPoint(mousePos);

        Debug.Log(spawnPos);
        Instantiate(ball, spawnPos, Quaternion.identity);
    }

}
