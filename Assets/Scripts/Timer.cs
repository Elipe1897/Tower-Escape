using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private TMP_Text textTimer;
    private float timer = 0.0f;
    private bool isTimer = false;

    private void Start()
    {
        isTimer = true;
    }

    public void Stoptimer()
    {
        isTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Displaytime()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        textTimer.text=string.Format("{0:00}:{1:00}", minutes, seconds); 
    }
}
