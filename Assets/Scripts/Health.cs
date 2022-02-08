using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    public static Health instance; // Creates a instance called Health.
    public int maxHealth = 3; // A variable for your max health.
    public int currentHealth; // A variable for you current health.
    public Image[] hearts; // A variable for the hearts array.
    public Sprite fullheart; // A variable for the full heart sprite.
    public Sprite emptyheart; // A variable for the empty heart sprite.


    private void Awake()
    {
        instance = this; // It assigns itself as a instance.
    }
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = 3; // When the game starts your health is set to 3.
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
        if (currentHealth == 0)
        {
            transform.position = new Vector3(-20, 20, 0);
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 1; // makes you lose health
    }
    public void AcidDamage()
    {
        currentHealth = 0; // makes you ded
    }
    
}
