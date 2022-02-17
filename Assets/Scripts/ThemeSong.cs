using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSong : MonoBehaviour
{
    public AudioSource theme; // varible for themesong sound - Elias s
    // Start is called before the first frame update
    void Start()
    {
        theme = GetComponent<AudioSource>();  // sound - Elias 
    }

    // Update is called once per frame
    void Update()
    {
        theme.Play();
    }
}
