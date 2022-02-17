using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Elias 
public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Toxic" || collision.transform.tag == "Player" || collision.transform.tag == "Player1")
        {
            Destroy(gameObject); // om objektn med taggarna "Toxic","Player","Player" nuddar så tars objektet koden ligger på borts
        }
    }
}
