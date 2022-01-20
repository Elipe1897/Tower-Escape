using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HealthP1 : MonoBehaviour
{
    public static HealthP1 instance; // Creates a instance called Health.
    public int maxHealth = 3; // A variable for your max health.
    public int currentHealth; // A variable for you current health.
    public Image[] hearts; // A variable for the hearts array.
    public Sprite fullheart; // A variable for the full heart sprite.
    public Sprite emptyheart; // A variable for the empty heart sprite.
    public Animator aanimator;


    private void Awake()
    {
        instance = this; // It assigns itself as a instance.
    }
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = 3; // When the game starts your health is set to 3.
        aanimator = GetComponent<Animator>();
    }
    private void Update()
    {
        // If you have full health it will show all full hearts but everytime you lose health one heart will become a empty heart.
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullheart;
            }
            else
            {
                hearts[i].sprite = emptyheart;
            }
        }
        // If your health is below 1 the "GameOver" scene will load.
        /*if (currentHealth < 1)
          {
              SceneManager.LoadScene("Death");
          }*/
    }

    public void TakeDamage2()
    {
        currentHealth -= 1; // makes you lose health
        aanimator.SetBool("TakeDamage", true);
    }
    public void AcidDamage2()
    {
        currentHealth = 0; // makes you ded
    }

}