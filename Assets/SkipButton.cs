using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{

    public string Platformer;
    

    public void OnSkipButtonClick()
    {
        SceneManager.LoadScene("Platformer");
    }
}