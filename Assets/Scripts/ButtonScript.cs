using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Leo N
public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void heheheha()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=Sag4AGymNr0&ab_channel=HaVoCGaming"); // hemlig knappt i spelet som man kan trycka på 
    }
    public void play()
    {
        SceneManager.LoadScene("Main"); //Loads the game scene 
    }
    public void settings()
    {
        SceneManager.LoadScene("Settings"); //Loads the settings scene
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("MainMeny"); //Loads the credit scene 


    }

    public void credit()
    {
        SceneManager.LoadScene("Credits"); //Loads the credit scene 


    }
    public void quit()
    {
        Application.Quit(); //exits/shuts down the game 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
