using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movment : MonoBehaviour
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
        if(Input.GetKey(KeyCode.LeftArrow))     //om man trycker ner v�nsterpilen �ker Player2 v�nster -Lisa
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.RightArrow))    //om man trycker ner g�gerpilen �ker Player2 h�ger -Lisa
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))  //om man trycker ner upp�tpilen hoppar Player2 -Lisa
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
    }
}
