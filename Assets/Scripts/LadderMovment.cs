using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Lisa 
public class LadderMovment : MonoBehaviour
{
    private float vertical;       //variabel f�r att kunna r�ra sig vertikalt    
    private float speed = 8f;     //variabel f�r speed 
    private bool isLadder;          //variabel f�r att kunna se om man �r vid en stege 
    private bool isClimbing;      //variabel f�r att se om man redan kl�ttrar 
    public Animator animator;

    [SerializeField] private Rigidbody2D rb; // variable f�r rigibody


    private void Start()
    {
        animator = GetComponent<Animator>(); // leo s 
    }
    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical"); // g�r s� att man r�r sig upp och ner med pilar och w,s 
        if (isLadder && Mathf.Abs(vertical) >0)  // om isladder och vertical �r st�rre �n 0 s� s�ts isClimbing true och animator "isClimbing" 
        {
            isClimbing = true;
            animator.SetBool("isClimbing", true); // Leo s 
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing == true) // om isclimbing = true s� set rb.gravity scale lika med 0 och rigibodyns force �ker upp�t 
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
        if (collision.CompareTag("Ladder"))  // om kollsion mer taggen Ladder s� s�tt isladder = true och animator blir ocks� true och spelas 
        {
            isLadder = true;
            animator.SetBool("isClimbing", true); // leo s 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder")) // om kollison sl�pper med taggen Ladder set isLadder = false och isCLimbing = false och animator = false 
        {
            isLadder = false;
            isClimbing = false;
            animator.SetBool("isClimbing", false); // leo s 
        }
    }
}
