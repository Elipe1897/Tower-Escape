using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovment : MonoBehaviour
{
    private float vertical;       //variabel för att kunna röra sig vertikalt -Lisa     
    private float speed = 8f;     //variabel för speed -Lisa
    private bool isLadder;          //variabel för att kunna se om man är vid en stege -Lisa
    private bool isClimbing;      //variabel för att se om man redan klättrar -Lisa
    public Animator animator;

    [SerializeField] private Rigidbody2D rb;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(vertical) >0) 
        {
            isClimbing = true;
            animator.SetBool("isClimbing", true);
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else 
        {
            rb.gravityScale = 4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder")) 
        {
            isLadder = true;
            animator.SetBool("isClimbing", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            animator.SetBool("isClimbing", false);
        }
    }
}
