using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    // Movement Speed
    public float speed = 100.0f;

    // Use this for initialization
    void Start()
    {
        Globals.Balls++;
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    void OnBecameInvisible()
    {
        Globals.Balls--;
        Destroy(gameObject);
    }

}
