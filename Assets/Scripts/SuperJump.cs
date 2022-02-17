using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player" || collision.transform.tag == "Player1")
        {
            Destroy(gameObject);
        }
    }
}
