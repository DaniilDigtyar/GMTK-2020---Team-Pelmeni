using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{ 
    public int lifespan = 1;
    
    public Sprite BrickDamaged;
    private SpriteRenderer render;
    
    public Ball colliderBall;
    public GameObject extraBall;




    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
                
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (lifespan >= 1)
        {
            render.sprite = BrickDamaged;
            lifespan--;
        }else if (lifespan == 0)
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    //Just destroy brick
                    Destroy(this.gameObject);
                    break;
                case 1:
                    //Increase ball speed by a factor of 1.25
                    
                    Destroy(this.gameObject);
                    
                    //colliderBall = GameObject.FindGameObjectWithTag("ball").GetComponent<Speed>();
                    //colliderBall.SetSpeed(1000.0f);
                    break;
                case 2:
                    //Increase number of balls. Adds 1 ball.
                    Destroy(this.gameObject);
                    GameObject newBall;
                    newBall = Instantiate(extraBall, transform.position, transform.rotation); //Try to make it appear where the previous brick was
                    break;
            }

            //case 3 = increase paddle size
            //case 4 = decrease paddle size
            //case 5 = change colour of bricks
            //case 6 = rotate screen 90º
            //case 7 = change brick distribution
        }
    }
}
 