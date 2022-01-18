using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movment : MonoBehaviour
{
    [SerializeField]                   //variabler som håller koll på vilka tangenter som styr Player 1 -Lisa
    private KeyCode Left;
    [SerializeField]
    private KeyCode Right;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    const float groundCheckRadius = 0.2f;
    [SerializeField, Range(1, 10)]      //variabel som bestämmer hur snabbt man går -Lisa
    private float speed = 4;
    [SerializeField] bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {

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
            if (isGrounded = true && (Input.GetKey(KeyCode.UpArrow))) //om man nuddar en plattform och trycker ner upp piltangenten så hoppar Player2 -Lisa
            {
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
            }

    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))     //om man trycker ner vänstra pilt<ngänten åker Player2 vänster -Lisa
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))    //om man trycker ner högra piltangänten åker Player2 höger -Lisa
        {
            transform.position += new Vector3(speed, 0, 0) * Time.fixedDeltaTime;
        }

        /* if (isGrounded = true && (Input.GetKeyDown(KeyCode.W)))  //om man trycker ner "W" hoppar Player1
         {
             gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
         }*/
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Spike")
        {
            Destroy(gameObject);
        }
    }
}
