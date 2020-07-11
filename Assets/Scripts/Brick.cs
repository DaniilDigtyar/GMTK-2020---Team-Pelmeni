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
            Destroy(this.gameObject);
        }
    }
}
 