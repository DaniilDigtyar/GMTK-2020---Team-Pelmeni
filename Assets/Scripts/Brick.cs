using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{ 
    // Lifespan
    public int lifespan = 1;
    
    // Sprites
    public Sprite BrickDamaged;
    private SpriteRenderer render;
    
    // Ball interaction
    public Ball colliderBall;
    public GameObject ball;

    // Paddle interaction
    public GameObject paddle;
    Vector3 scaleChange = new Vector3(0.2f, 0, 0);


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
            switch (Random.Range(0, 2))
            {
                case 0:
                    //Just destroy brick
                    //1/10
                    Destroy(this.gameObject);
                    print("case 0");
                    break;
                case 1:
                    //Increase ball speed by a factor of 1.25
                    //2
                    Destroy(this.gameObject);
                    increaseBallSpeed();
                    print("case 1");
                    break;
                case 2:
                    //Increase number of balls. Adds 1 ball.
                    //2
                    Destroy(this.gameObject);
                    addBall();
                    print("case 2");
                    
                    break;
                case 3:
                    //Increase Paddle size
                    //1
                    Destroy(this.gameObject);
                    increasePaddle();
                    print("case 3");
                    break;
                case 4:
                    //Decrease Paddle size
                    //3
                    Destroy(this.gameObject);
                    decreasePaddle();
                    print("case4");
                    break;
            }

            //case 5 = change colour of bricks
            //case 6 = rotate screen 90º
            //case 7 = billiard bricks
        }
    }
    
    private void increaseBallSpeed()
    {
        colliderBall.SetSpeed(10.0f);
    }

    private void addBall()
    {
        GameObject newBall;
        newBall = Instantiate(ball, transform.position, transform.rotation); //Try to make it appear where the previous brick was
    }
   
    private void increasePaddle()
    {
        paddle = GameObject.Find("Paddle");
        paddle.transform.localScale += scaleChange;
    }

    private void decreasePaddle()
    {
        paddle = GameObject.Find("Paddle");
        if (paddle.transform.localScale.x >= 1)
        {
            paddle.transform.localScale -= scaleChange;
        }
    }
}
 