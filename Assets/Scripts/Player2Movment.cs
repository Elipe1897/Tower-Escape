using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player2Movment : MonoBehaviour
{
    [SerializeField]                   //variabler som håller koll på vilka tangenter som styr Player 1 -Lisa
    private KeyCode Left;
    [SerializeField]
    private KeyCode Right;
    [SerializeField] Transform groundCheckCollider; // gör så man kan ändra i unity - Elias 
    [SerializeField] LayerMask groundLayer; // gör så man kan ändra i unity - Elias 
    public Animator animator;
    public AudioSource Hoppi; // hoppi ljud variabel - Elias 
    const float groundCheckRadius = 0.2f;
    [SerializeField, Range(1, 10)]      //variabel som bestämmer hur snabbt man går -Lisa
    private float speed = 5;   // sets speed till 5 - Elias 
    [SerializeField] bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        Hoppi = GetComponent<AudioSource>(); // gets hoppi ljud - Elias
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    void GroundCheck()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
            if (isGrounded = true && (Input.GetKey(KeyCode.UpArrow))) //om man nuddar en plattform och trycker ner "W" så hoppar Player1 -Lisa
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
                Hoppi.Play(); // plays jump sound - Elias 
                animator.SetBool("isJumping", true);

            }
            else
            {
                animator.SetBool("isJumping", false);
            }

    }




    // Update is called once per frame
    void Update()
    {
       
       
        float moveX = Input.GetAxis("Horizontal"); // moveX varible för horizontal - Elias 
        transform.position += new Vector3(moveX, 0f, 0f) * Time.deltaTime * speed; // movement - Elias 

        if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("isRunning", true);

        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("isRunning", true);

        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("isRunning", false);
        }

        Vector3 characterScale = transform.localScale; // spelarens ui byter rikning beroende vilken knapp som trycks - Elias 

        if (Input.GetAxis("Horizontal") < 0) 
        {
            characterScale.x = -0.35f;
        }

        if (Input.GetAxis("Horizontal") > 0) 
        {
            characterScale.x = 0.35f;

        }
        transform.localScale = characterScale;
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.transform.tag == "Spike") // om kollison med taggen Spike tappa 1 hjärta - leo s 
        {
            Health.instance.TakeDamage();
            
        }
        if (collision.transform.tag == "Toxic") // om kollison med taggen Toxic dö direkt - leo s 
        {
            Health.instance.AcidDamage();
            transform.position = new Vector3(-20, 20, 0);
        }
       

    }
}
