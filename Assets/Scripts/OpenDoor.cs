using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Animator animator; // A variable for the animator - Leo S
    private void Start()
    {
        animator = GetComponentInParent<Animator>(); // Gets the animator from the parent - Leo S
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.transform.tag == "Player1") // If it collides with player 1 it loads the open door animation and teleports the key to a box - Leo S
        {
            animator.SetBool("isKeyCollected", true);
            transform.position = new Vector3(-40, 20, 0f);
        }
        if (collision.transform.tag == "Player") // If it collides with player  it loads the open door animation and teleports the key to a box - Leo S
        {
            animator.SetBool("isKeyCollected", true);
            transform.position = new Vector3(40, 20, 0f);
        }
        if (collision.transform.tag == "Ded")  // if the key collides with the box "ded" the purple victory scene loads - Leo S
        {
            SceneManager.LoadScene("LilaVictory 1");
        }
        if (collision.transform.tag == "Dead")// if the key collides with the box "ded" the orange victory scene loads - Leo S
        {
            SceneManager.LoadScene("LilaVictory 2");
        }

    }
}
