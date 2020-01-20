using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnCollision : MonoBehaviour
{
    public AudioSource musicSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        musicSource.Play();
    }
}
