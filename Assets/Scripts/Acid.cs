using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    public float timer = 0;

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       
            if(timer > 2)
        {
            transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
        }
        
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Health.instance.AcidDamage();
        }
    }*/
}
