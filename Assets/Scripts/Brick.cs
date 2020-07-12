using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{ 
    // Lifespan
    public int lifespan = 1;
    
    // Sprites
    public Sprite BrickDamaged;
    private SpriteRenderer renderer;

    
    
    // Ball interaction
    public Ball colliderBall;
    public GameObject ball;
    public GameObject ballCopy;

    // Paddle interaction
    public GameObject paddle;
    Vector3 scaleChange = new Vector3(0.2f, 0, 0);


    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        

        if (lifespan >= 1)
        {
            renderer.sprite = BrickDamaged;
            lifespan--;

        }else if (lifespan == 0)
        {
            Destroy(this.gameObject);
            
            switch (Random.Range(0, 9))
            {
                case 0:
                case 1:
                    //Increase ball speed
                    increaseBallSpeed();
                    changeColour(renderer);
                    break;
                case 2:
                case 3:
                    //Adds 1 ball.
                    addBall();
                    changeColour(renderer);
                    break;
                case 4:
                    //Increase Paddle size
                    increasePaddle();
                    changeColour(renderer);
                    break;
                case 5:
                case 6:
                    //Decrease Paddle size
                    decreasePaddle();
                    changeColour(renderer);
                    break;
                case 7:
                case 8:
                    //Change Brick Colour
                    changeColour(renderer);
                    break;
            }
        }
    }
    
    private void increaseBallSpeed()
    {//Not working
        colliderBall.SetSpeed(2.0f);
    }

    private void addBall()
    {
        GameObject newBall;
        newBall = Instantiate(ballCopy, transform.position, transform.rotation);
    }
   
    private void increasePaddle()
    {
        paddle = GameObject.Find("Paddle");
        paddle.transform.localScale += scaleChange;
    }

    private void decreasePaddle()
    {
        paddle = GameObject.Find("Paddle");
        if (paddle.transform.localScale.x >= 0.3)
        {
            paddle.transform.localScale -= scaleChange;
        }
    }

    public void changeColour (SpriteRenderer renderer)
    {
        List<string> colourList = new List<string> { "White", "Yellow", "Orange", "Pink", "Purple", "DarkBlue", "LightBlue", "Green" };
        string temp = colourList[Random.Range(0, (colourList.Count))];
        
        switch (temp)
        {
            case "White":
                Color white = new Color(1f, 1f, 1f, 1f);
                setColour(white);
                break;
            case "Yellow":
                Color yellow = new Color(1f, 0.92f, 0.016f, 1f);
                setColour(yellow);
                break;
            case "Orange":
                Color orange = new Color(1f, 0.5686275f, 0f, 1f);
                setColour(orange);
                break;
            case "Pink":
                Color pink = new Color(0.8470589f, 0.1058824f, 0.3764706f, 1f);
                setColour(pink);
                break;
            case "Purple":
                Color purple = new Color(0.482353f, 0.1215686f, 0.6352941f, 1f);
                setColour(purple);
                break;
            case "DarkBlue":
                Color darkBlue = new Color(0.2235294f, 0.2862745f, 0.6705883f, 1f);
                setColour(darkBlue); 
                break;
            case "LightBlue":
                Color lightBlue = new Color(0.1647059f, 0.6078432f, 0.8980393f, 1f);
                setColour(lightBlue);
                break;
            case "Green":
                Color green = new Color(0.4862745f, 0.7019608f, 0.2588235f, 1f);
                setColour( green);
                break;
        }
    }

    private void setColour (Color colour)
    {
        foreach (GameObject Brick in GameObject.FindGameObjectsWithTag("brick"))
        {
            Brick.GetComponent<Renderer>().material.color = colour;
        }
        print(name);
    }
}
 