using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public GameObject splitLeft;
    public GameObject splitRight;
    public GameObject FullScreen;

    public GameObject Player1;
    public GameObject Player2;
    public float Distance_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance_ = Vector3.Distance(Player1.transform.position, Player2.transform.position);
        if (Distance_ <= 4.2)
        {
            fullScreen();
        }
        else
        {
            splitScreen();
        }


    }
    void splitScreen()
    {
        splitLeft.SetActive(true);
        splitRight.SetActive(true);
        FullScreen.SetActive(false);
    }
    void fullScreen()
    {
        splitLeft.SetActive(false);
        splitRight.SetActive(false);
        FullScreen.SetActive(true);
    }


}
