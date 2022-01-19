using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Health.instance.AcidDamage();
        }
    }
}
