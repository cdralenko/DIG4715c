using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;

   private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 movement = new Vector2(0, -1);
        rb2d.velocity = movement * speed;
    }
}
