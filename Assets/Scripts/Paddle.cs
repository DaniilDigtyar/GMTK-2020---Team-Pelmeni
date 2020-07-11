using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;
    public GameObject cameraObject;
    private Vector2 screenBounds;
    private float width;

    // Start is called before the first frame update
    void Start()
    {
        Camera MainCamera = cameraObject.GetComponent<Camera>();
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width,
                                                                 Screen.height,
                                                                 MainCamera.transform.position.z));
        width = transform.GetComponent<SpriteRenderer>().bounds.extents.x; // extends.x divides it by 2
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        float movement = speed * direction * Time.deltaTime; // Stable movement, non-dependant of FPS
        transform.Translate(movement, 0, 0); 
    }

    //Called after Update
    void LateUpdate()
    {
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, (screenBounds.x * -1) + width, screenBounds.x - width); // Parameters: position, min, max. FIX THIS. Static???? screenBounds = 10????
        transform.position = position;
    
    }
}
