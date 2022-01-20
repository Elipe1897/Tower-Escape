using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovment : MonoBehaviour
{
    private float vertical;       //variabel för att kunna röra sig vertikalt -Lisa     
    private float speed = 8f;     //variabel för speed -Lisa
    private bool isLadder;          //variabel för att kunna se om man är vid en stege -Lisa
    private bool isClimbing;      //variabel för att se om man redan klättrar -Lisa

    [SerializeField] private Rigidbody2D rb;

    

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(vertical) >0) 
        {
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder")) 
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
