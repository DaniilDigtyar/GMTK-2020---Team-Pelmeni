using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{ 
    public int lifespan = 1;
    public Sprite BrickDamaged;
    private SpriteRenderer render;
    public Ball colliderBall;

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
            switch (Random.Range(0, 1))
            {
                case 0:
                    //Just destroy brick
                    Destroy(this.gameObject);
                    break;
                case 1:
                    //Increase ball speed by a factor of 1.25
                    
                    Destroy(other.gameObject);
                    
                    //colliderBall = GameObject.FindGameObjectWithTag("Ball");
                    //colliderBall.SetSpeed(1000.0f);
                    break;
            }
            //case 2 = increase ball number
            //case 2 = increase paddle size
            //case 3 = decrease paddle size
            //case 4 = change colour of bricks
            //case 5 = rotate screen 90º
            //case 6 = change brick distribution
        }
    }
}
 