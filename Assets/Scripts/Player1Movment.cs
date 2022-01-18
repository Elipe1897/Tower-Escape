using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movment : MonoBehaviour
{
    [SerializeField]                   //variabler som h�ller koll p� vilka tangenter som styr Player 1 -Lisa
    private KeyCode Left;
    [SerializeField]
    private KeyCode Right;

    [SerializeField, Range(1, 10)]      //variabel som best�mmer hur snabbt man g�r -Lisa
    private float speed = 4;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))     //om man trycker ner "A" �ker Player1 v�nster -Lisa
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D))    //om man trycker ner "D" �ker Player1 h�ger -Lisa
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.W))  //om man trycker ner "W" hoppar Player1
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
    }
}
