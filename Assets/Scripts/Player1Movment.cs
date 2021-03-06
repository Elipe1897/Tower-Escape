using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Movment : MonoBehaviour
{
    
    [SerializeField]                   //variabler som h?ller koll p? vilka tangenter som styr Player 1 -Lisa
    private KeyCode Left;
    [SerializeField]
    private KeyCode Right;
    [SerializeField] Transform groundCheckCollider; // g?r s? man kan ?ndra i unity - Elias
    [SerializeField] LayerMask groundLayer; // g?r s? man kan ?ndra i unity - Elias
    public AudioSource Hoppi;  // hoppi ljud variabel - Elias 
    const float groundCheckRadius = 0.2f; // lisa 
    [SerializeField, Range(1, 10)]      //variabel som best?mmer hur snabbt man g?r -Lisa
    private float speed = 5;     // sets speed till 5 - Elias
    [SerializeField] bool isGrounded = false; // variable isGrounded = false - Elias 
    public Animator animator; // leo s 
    





    // Start is called before the first frame update
    void Start()
    {
        Hoppi = GetComponent<AudioSource>();  // gets hoppi ljud - Elias 
        animator = GetComponent<Animator>(); // leo s
      

    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    void GroundCheck()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
            if (isGrounded = true && (Input.GetKey(KeyCode.W))) //om man nuddar en plattform och trycker ner "W" s? hoppar Player1 -Lisa
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
                Hoppi.Play(); // plays jump sound - Elias 
                animator.SetBool("isGrounded", false);
          
            }
            else
            {
                animator.SetBool("isGrounded", true);
            }

    }




    // Update is called once per frame
    void Update()
    {
       
       float moveX = Input.GetAxis("Horizontal2");
        transform.position += new Vector3(moveX, 0f, 0f) * Time.deltaTime * speed; // movement - Elias 
        if (Input.GetAxis("Horizontal2") < 0) // If you run to the left the run animation plays - Elias
        {
            animator.SetBool("isRunning", true);
         
        }
        if (Input.GetAxis("Horizontal2") > 0)// If you run to the right the run animation plays - Elias
        {
            animator.SetBool("isRunning", true);
          
        }
        if (Input.GetAxis("Horizontal2") ==  0) // If you don't run the runanimation don't play - Elias
        {
            animator.SetBool("isRunning", false);
        }

        Vector3 characterScale = transform.localScale;  // spelarens ui byter rikning beroende vilken knapp som trycks - Elias 

        if (Input.GetAxis("Horizontal2") < 0)
        {
            characterScale.x = -0.35f;
        }

        if (Input.GetAxis("Horizontal2") > 0)
        {
            characterScale.x = 0.35f;

        }
        transform.localScale = characterScale;
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Spike") // om kollison med taggen Spike tappa 1 hj?rta - leo s 
        {
            HealthP1.instance.TakeDamage2();
        }
        if (collision.transform.tag == "Toxic")  // om kollison med taggen Toxic d? direkt - leo s 
        {
            HealthP1.instance.AcidDamage2();
            transform.position = new Vector3(-20, 20, 0);
            Debug.Log("Dead");
        }
       if(collision.transform.tag == "Player") // om kollsion tag = Player loada Death scene - Leo n
        {
            SceneManager.LoadScene("Death");
        }
       if(collision.transform.tag == "Platform") // om kollison tag = Platform then isGrounded = true - Lisa 
        {
            isGrounded = true;
        }
       
    }
    
}
