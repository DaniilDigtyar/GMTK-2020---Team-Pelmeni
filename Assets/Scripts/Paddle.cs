using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 7.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        float movement = speed * direction * Time.deltaTime; // Stable movement, non-dependant of FPS

        transform.Translate(movement, 0, 0);
        
    }

}
