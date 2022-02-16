using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance; // Does timer varible into an instance, instance means it can be accessed anywere in the code- Elias

    public TMP_Text textTimer; // varible for text - Elias

    [SerializeField]
    private float timer = 0.0f; // Timer varible = o - Elias

    private bool isTimer = false; // sets varible isTimer = false - Elias

    private void Start()
    {
        isTimer = true; // at start sets isTimer true - Elias
    }
    private void Awake()
    {
        instance = this; // asign it self an instance - Elias 
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
        int seconds = Mathf.FloorToInt(timer - minutes * 60);   // if seconds > 60 then minutes becomes 1 - Elias 
        textTimer.text=string.Format("{0:00}:{1:00}", minutes, seconds);  // Makes minutes at the left side of ":" and seconds right of the ":" - Elias 
    } 
    public void Stoptimer()
    {
        isTimer = false;      // sets isTimer = false - Elias 
    }

    public void ResetTimer()
    {
        timer = 0.0f; // sets timer = 0 - Elias
    }


}
