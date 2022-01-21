using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public Animator animator;
    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player1")
        {
            animator.SetBool("isKeyCollected", true);
            transform.position = new Vector3(-40, 20, 0f);
        }
        if (collision.transform.tag == "Player")
        {
            animator.SetBool("isKeyCollected", true);
            transform.position = new Vector3(40, 20, 0f);
        }
        if (collision.transform.tag == "Ded")
        {
            SceneManager.LoadScene("LilaVictory 1");
        }
        if (collision.transform.tag == "Dead")
        {
            SceneManager.LoadScene("LilaVictory 2");
        }

    }
}
