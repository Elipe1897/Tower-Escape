using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void heheheha()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=Sag4AGymNr0&ab_channel=HaVoCGaming");
    }
    public void play()
    {
        SceneManager.LoadScene("Main"); //Loads the game scene - Leo N
    }
    public void settings()
    {
        SceneManager.LoadScene("Settings"); //Loads the settings scene - Leo N
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("MainMeny"); //Loads the credit scene - Leo N


    }

    public void credit()
    {
        SceneManager.LoadScene("Credits"); //Loads the credit scene - Leo N


    }
    public void quit()
    {
        Application.Quit(); //exits/shuts down the game - Leo n
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
