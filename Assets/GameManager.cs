﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Globals.Balls == 0)
        {
            SceneManager.LoadScene("Lose");
        }

        if(Globals.Bricks == 0)
        {
            SceneManager.LoadScene("Not Lose");
        }
    }
}
