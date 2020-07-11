using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10.0f;
    public Camera MainCamera; 
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; 
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        Globals.Balls++;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Globals.Balls--;
        Destroy(this);
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        Quaternion rotationPos = transform.rotation;
        if (viewPos.x < (screenBounds.x * -1 + objectWidth))
        {
            print("!!1");
            rotationPos = Quaternion.Inverse(rotationPos);
        }
        else if (viewPos.x > (screenBounds.x - objectWidth))
        {
            print("!!2");
            rotationPos = Quaternion.Inverse(rotationPos);
        }

        //viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth , screenBounds.x - objectWidth );
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 - objectHeight * 2 ,  screenBounds.y + objectHeight);
        transform.position = viewPos;
        transform.rotation = rotationPos;
    }
}
