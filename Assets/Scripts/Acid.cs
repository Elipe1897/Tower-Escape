using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    public float timer = 0; // a variable for the timer
  

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // It makes the timer count seconds
       
            if(timer > 2) //if the timer is over 2 seconds the acid will start to rise Leo S
        {
            transform.position += new Vector3(0, 1f, 0) * Time.deltaTime;
        }
        
    }
}
