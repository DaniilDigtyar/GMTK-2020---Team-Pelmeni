using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void OnClickPlay()
    {
        SceneManager.LoadScene("Level");
    }
}
