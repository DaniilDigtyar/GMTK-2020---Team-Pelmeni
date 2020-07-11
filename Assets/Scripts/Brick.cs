using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int lifespan = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
                
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (lifespan > 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite == BrickDamaged;
            lifespan--;
        }else if (lifespan == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
