using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public TMP_Text textTimer;

    [SerializeField]
    private float timer = 0.0f;

    private bool isTimer = false;

    private void Start()
    {
        isTimer = true;
    }
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimer)
        {
            timer += Time.deltaTime;
            Displaytime();
        }
    }

    void Displaytime()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        textTimer.text=string.Format("{0:00}:{1:00}", minutes, seconds); 
    } 
    public void Stoptimer()
    {
        isTimer = false;
    }

    public void ResetTimer()
    {
        timer = 0.0f;
    }


}
