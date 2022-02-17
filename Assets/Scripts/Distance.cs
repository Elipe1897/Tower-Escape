using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public float Distance_;

    public GameObject split1;
    public GameObject split2;
    public GameObject fullScreen;


    // Update is called once per frame
    void Update()
    {
        Distance_ = Vector3.Distance(Player1.transform.position, Player2.transform.position);
        if(Distance_ < 4.2)
        {
            fullscreen();
        }
        else
        {
            splitScreen();
        }
    }
    void fullscreen()
    {
        split1.SetActive(false);
        split2.SetActive(false);
        fullScreen.SetActive(true);
    }
    void splitScreen()
    {
        split1.SetActive(true);
        split2.SetActive(true);
        fullScreen.SetActive(false);

    }
}
