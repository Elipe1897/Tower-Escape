using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSong : MonoBehaviour
{
    public AudioSource theme;
    // Start is called before the first frame update
    void Start()
    {
        theme = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        theme.Play();
    }
}
