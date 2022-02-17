using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// leo s 
public class Acid : MonoBehaviour
{
    public float timer = 0; // a variable for the timer 


    private void Start()
    {
    }
    // Update is called once per frame
    void Update() // If the timer is above 2 seconds the acid will start to rise 
    {
        timer += Time.deltaTime; 

        if (timer > 2) 
        {
            transform.position += new Vector3(0, 1f, 0) * Time.deltaTime;
        }
        
    }
}
