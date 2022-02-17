using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour
{
    public GameObject Player1; // A variable for Player 1 - Leo S
    public GameObject Player2; // A variable for Player 2 - Leo S
    public float Distance_; // A variable for The distance between them - Leo S

    public GameObject split1; // A variable for splitscreen camera 1 - Leo S
    public GameObject split2; // A variable for splitscreen camera 2 - Leo S
    public GameObject fullScreen; // A variable for fullscreen camera - Leo S


    // Update is called once per frame
    void Update()// It calculates the distance between the players. If the distance between the players are less than 4.2 it uses the fullscreen camera else it usees the splitscreen cameras - Leo S
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
    void fullscreen() // It turns off the split screen cameras and turns on the fullscreen camera - Leo S
    {
        split1.SetActive(false);   
        split2.SetActive(false);     
        fullScreen.SetActive(true);  
    }
    void splitScreen() // It turns on the split screen cameras and turns off the fullscreen camera - Leo S
    {
        split1.SetActive(true); 
        split2.SetActive(true); 
        fullScreen.SetActive(false); 

    }
}
