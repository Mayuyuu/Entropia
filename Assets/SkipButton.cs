using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{

    public string Platformer;
    private AudioManager audioManager;
    

    public void OnSkipButtonClick()
    {
        StartCoroutine(ButtonSound());
        SceneManager.LoadScene("Platformer");
        
         
    }

    IEnumerator ButtonSound()
    {
        if(audioManager != null)
        {
            AudioManager._Instance.PlaySFX(audioManager.ButtonUi);
        }
        yield return new WaitForSeconds(0.5f);
    }
}
