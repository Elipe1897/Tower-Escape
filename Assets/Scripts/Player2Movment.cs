using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player2Movment : MonoBehaviour
{
    [SerializeField]                   //variabler som h�ller koll p� vilka tangenter som styr Player 1 -Lisa
    private KeyCode Left;
    [SerializeField]
    private KeyCode Right;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;
    public Animator animator;
    public AudioSource Hoppi;
    const float groundCheckRadius = 0.2f;
    [SerializeField, Range(1, 10)]      //variabel som best�mmer hur snabbt man g�r -Lisa
    private float speed = 5;
    [SerializeField] bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        Hoppi = GetComponent<AudioSource>();
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
            if (isGrounded = true && (Input.GetKey(KeyCode.UpArrow))) //om man nuddar en plattform och trycker ner "W" s� hoppar Player1 -Lisa
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
                Hoppi.Play();
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
        /*if (Input.GetKey(KeyCode.LeftArrow))     //om man trycker ner v�nstra pilt<ng�nten �ker Player2 v�nster -Lisa
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))    //om man trycker ner h�gra piltang�nten �ker Player2 h�ger -Lisa
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }*/
       
        float moveX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(moveX, 0f, 0f) * Time.deltaTime * speed;
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

        Vector3 characterScale = transform.localScale;

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
        if (collision.transform.tag == "Spike")
        {
            Health.instance.TakeDamage();
            
        }
        if (collision.transform.tag == "Toxic")
        {
            Health.instance.AcidDamage();
            transform.position = new Vector3(-20, 20, 0);
        }
    }
}
