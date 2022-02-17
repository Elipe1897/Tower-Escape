using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Leo s 
public class Health : MonoBehaviour
{
    public static Health instance; // Creates a instance called Health. - Leo S
    public int maxHealth = 3; // A variable for your max health. - Leo S
    public int currentHealth; // A variable for you current health. - Leo S
    public Image[] hearts; // A variable for the hearts array. - Leo S
    public Sprite fullheart; // A variable for the full heart sprite. - Leo S
    public Sprite emptyheart; // A variable for the empty heart sprite. - Leo S


    private void Awake()
    {
        instance = this; // It assigns itself as a instance. - Leo S
    }
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = 3; // When the game starts your health is set to 3. - Leo S
    }
    private void Update()
    {
        // If you have full health it will show all full hearts but everytime you lose health one heart will become a empty heart.-  Leo S
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

        if (currentHealth == 0)
        {
            transform.position = new Vector3(-20, 20, 0);
        }
    }

    public void TakeDamage()
    {
        currentHealth -= 1; // Makes you lose 1 health when you touch a spike - Leo S
    }
    public void AcidDamage()
    {
        currentHealth = 0; //  Makes your health 0 when you touch the acid - Leo S
    }
    
}
