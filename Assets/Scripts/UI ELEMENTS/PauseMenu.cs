using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   //[SerializeField] GameObject pauseMenu;

    public static bool GameIsPaused = false;


    void Awake()
    {
        CloseWindow();
    }
   void Update()
   {
//Debug.Log(Input.GetButton("Pause"));
    if(Input.GetButtonDown("Pause"))
    {
        Pause();
    }

   }
    
   public void Pause()
   {
    
        if(!GameIsPaused)
        {
             transform.GetChild(0).gameObject.SetActive(true);
            GameIsPaused = true;
        }
        else
        {
            Resume();
        }
       
   }

   public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        
    }

    public void Resume()
    {
        CloseWindow();
        GameIsPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void CloseWindow()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
