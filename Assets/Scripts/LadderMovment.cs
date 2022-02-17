using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lisa 
public class LadderMovment : MonoBehaviour
{
    private float vertical;       //variabel för att kunna röra sig vertikalt    
    private float speed = 8f;     //variabel för speed 
    private bool isLadder;          //variabel för att kunna se om man är vid en stege 
    private bool isClimbing;      //variabel för att se om man redan klättrar 
    public Animator animator;

    [SerializeField] private Rigidbody2D rb; // variable för rigibody


    private void Start()
    {
        animator = GetComponent<Animator>(); // leo s 
    }
    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical"); // gör så att man rör sig upp och ner med pilar och w,s 
        if (isLadder && Mathf.Abs(vertical) >0)  // om isladder och vertical är större än 0 så säts isClimbing true och animator "isClimbing" 
        {
            isClimbing = true;
            animator.SetBool("isClimbing", true); // Leo s 
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing == true) // om isclimbing = true så set rb.gravity scale lika med 0 och rigibodyns force åker uppåt 
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else   // annars set rigibody gravityscale = 4
        {
            rb.gravityScale = 4f; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))  // om kollsion mer taggen Ladder så sätt isladder = true och animator blir också true och spelas 
        {
            isLadder = true;
            animator.SetBool("isClimbing", true); // leo s 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder")) // om kollison släpper med taggen Ladder set isLadder = false och isCLimbing = false och animator = false 
        {
            isLadder = false;
            isClimbing = false;
            animator.SetBool("isClimbing", false); // leo s 
        }
    }
}
