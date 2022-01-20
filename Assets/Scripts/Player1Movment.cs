using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        Hoppi = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
            if (isGrounded = true && (Input.GetKey(KeyCode.W))) //om man nuddar en plattform och trycker ner "W" så hoppar Player1 -Lisa
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
                Hoppi.Play();
            }

    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))     //om man trycker ner "A" åker Player1 vänster -Lisa
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.D))    //om man trycker ner "D" åker Player1 höger -Lisa
        {
            transform.position += new Vector3(speed, 0, 0) * Time.fixedDeltaTime;
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
        }
    }

}
