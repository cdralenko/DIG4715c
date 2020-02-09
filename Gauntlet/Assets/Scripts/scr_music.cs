using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_music : MonoBehaviour
{
    public AudioClip music1;
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = music1;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
