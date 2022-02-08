using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XtraLife : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player1")
        {
            Destroy(gameObject);
            HealthP1.instance.GetHealth2();
        }
        if(collision.transform.tag == "Player")
        {
            Destroy(gameObject);
            Health.instance.GetHealth();
        }
    }
}
