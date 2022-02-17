using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    public float timer = 0; // a variable for the timer - Leo S


    private void Start()
    {
    }
    // Update is called once per frame
    void Update() // If the timer is above 2 seconds the acid will start to rise - Leo S
    {
        timer += Time.deltaTime; 

        if (timer > 2) 
        {
            transform.position += new Vector3(0, 1f, 0) * Time.deltaTime;
        }
        
    }
}
