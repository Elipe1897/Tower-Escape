using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1Movment : MonoBehaviour
{
    
    [SerializeField]                   //variabler som håller koll på vilka tangenter som styr Player 1 -Lisa
    private KeyCode Left;
    [SerializeField]
    private KeyCode Right;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;
    public AudioSource Hoppi;  // hoppi ljud variabel - Elias 
    const float groundCheckRadius = 0.2f;
    [SerializeField, Range(1, 10)]      //variabel som bestämmer hur snabbt man går -Lisa
    private float speed = 5;
    [SerializeField] bool isGrounded = false;
    public Animator animator;
    public float timer = 0;
    public float freezeTimer = 0;
    public bool ezeerf = false;
    public bool remit = false;






    // Start is called before the first frame update
    void Start()
    {
        Hoppi = GetComponent<AudioSource>();  // gets hoppi ljud - Elias 
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
            if (isGrounded = true && (Input.GetKey(KeyCode.W))) //om man nuddar en plattform och trycker ner "W" så hoppar Player1 -Lisa
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
        if (Input.GetAxis("Horizontal2") < 0)
        {
            animator.SetBool("isRunning", true);
         
        }
        if (Input.GetAxis("Horizontal2") > 0)
        {
            animator.SetBool("isRunning", true);
          
        }
        if (Input.GetAxis("Horizontal2") ==  0)
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
        if (remit == true)
        {
            startTimer();
        }
        if (isGrounded = true && (Input.GetKey(KeyCode.W)))
        {
            superJump();
        }
        if (ezeerf == true)
        {
            startFTimer();
        }
        if (freezeTimer < 2 && freezeTimer > 0.1)
        {
            transform.position -= new Vector3(moveX, 0f, 0f) * Time.deltaTime * speed;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Spike")
        {
            HealthP1.instance.TakeDamage2();
        }
        if (collision.transform.tag == "Toxic")
        {
            HealthP1.instance.AcidDamage2();
            transform.position = new Vector3(-20, 20, 0);
            Debug.Log("Dead");
        }
       if(collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("Death");
        }
       if(collision.transform.tag == "Platform")
        {
            isGrounded = true;
        }
        if (collision.transform.tag == "SuperJump")
        {
            remit = true;
        }
        if (collision.transform.tag == "Freeze")
        {
            ezeerf = true;

        }
    }
    void superJump()
    {
        if (timer < 3 && timer > 0.1)
        { gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0.3f), ForceMode2D.Impulse); }
    }
    void startTimer()
    {
        timer += Time.deltaTime;
    }
    void startFTimer()
    {
        freezeTimer += Time.deltaTime;

    }

}
