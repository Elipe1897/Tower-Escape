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
    public AudioSource Hoppi;
    const float groundCheckRadius = 0.2f;
    [SerializeField, Range(1, 10)]      //variabel som bestämmer hur snabbt man går -Lisa
    private float speed = 5;
    [SerializeField] bool isGrounded = false;
    public Animator animator;

    public int doubbleJump = 0;




    // Start is called before the first frame update
    void Start()
    {
        Hoppi = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        doubbleJump = 0;

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
                Hoppi.Play();
                animator.SetBool("isGrounded", false);
               powerUp();
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
        transform.position += new Vector3(moveX, 0f, 0f) * Time.deltaTime * speed;
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

        Vector3 characterScale = transform.localScale;

        if (Input.GetAxis("Horizontal2") < 0)
        {
            characterScale.x = -0.35f;
        }

        if (Input.GetAxis("Horizontal2") > 0)
        {
            characterScale.x = 0.35f;

        }
        transform.localScale = characterScale;
        if(doubbleJump == 2)
        {
            isGrounded = false;
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
    }
    public void powerUp()
    {
        if (doubbleJump < 2 && Input.GetKey(KeyCode.W))
        {
            doubbleJump += 1;
        }

    }

}
