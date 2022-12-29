using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{
    public Button toggleText;
    public GameObject windowBlue;
    public GameObject windowOrange;
    // Start is called before the first frame update
    void Start()
    {
            windowBlue.SetActive(false);
            windowOrange.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("t"))
        {
            ShowOrHide();
        }
        
    }

    public void ShowOrHide()
    {
        if(windowBlue.activeSelf == false && windowOrange.activeSelf == false)
            {
                windowBlue.gameObject.SetActive(true);
                toggleText.GetComponentInChildren<Text>().text = "HIDE";
            }
        else
        {
            windowBlue.SetActive(false);
            windowOrange.SetActive(false);
            toggleText.GetComponentInChildren<Text>().text = "SHOW";
        }
    }

    public void ShowOtherBlue()
    {
        if(windowBlue.activeSelf == true)
        {
            windowBlue.SetActive(false);
            windowOrange.SetActive(true);
        }
    }

    public void ShowOtherOrange()
    {
        if(windowOrange.activeSelf == true)
        {
            windowBlue.SetActive(true);
            windowOrange.SetActive(false);
        }
    }
}
