using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{ 
    public int lifespan = 1;
    public Sprite BrickDamaged;
    private SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
                
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (lifespan >= 1)
        {
            render.sprite = BrickDamaged;
            lifespan--;
        }else if (lifespan == 0)
        {
            //random number 0-6
            //switch
            //case 0 = just destroy brick
            //case 1 = increase ball speed
            //case 2 = increase ball number
            //case 2 = increase paddle size
            //case 3 = decrease paddle size
            //case 4 = change colour of bricks
            //case 5 = rotate screen 90º
            //case 6 = change brick distribution
            Destroy(this.gameObject);
        }
    }
}
 