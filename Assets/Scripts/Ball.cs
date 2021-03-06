﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    // Movement Speed
    public float speed = 100.0f;

    //Rigidbody
    public Rigidbody2D ballRB;

    //Audio
    public AudioClip impact;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        Globals.Balls++;
        ballRB = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && ballRB.velocity == new Vector2(0,0))
        {
            ballRB.velocity = Vector2.up * speed;
        }
    }
    
    void OnBecameInvisible()
    {
        Globals.Balls--;
        Destroy(gameObject);
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        audioSource.PlayOneShot(impact, 0.25f);

        // Hit the Racket?
        if (col.gameObject.tag == "paddle")
        {
            print("ok");
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = this.speed + newSpeed; 
        //GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;

    }
}
