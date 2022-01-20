using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovment : MonoBehaviour
{
    private float vertical;       //variabel f�r att kunna r�ra sig vertikalt -Lisa     
    private float speed = 8f;     //variabel f�r speed -Lisa
    private bool isLadder;          //variabel f�r att kunna se om man �r vid en stege -Lisa
    private bool isClimbing;      //variabel f�r att se om man redan kl�ttrar -Lisa
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
