using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SKIPCINEMATIC : MonoBehaviour
{
    // private AudioManager audioManager;
    // public void SFXButtons()
    // {
    //     AudioManager._Instance.PlaySFX(audioManager.ButtonUi);
    // }
    // // Start is called before the first frame update
    public void OnSkipButtonClick()
    {
        // StartCoroutine(ButtonSound());
        SceneManager.LoadScene("Tutorial");


    }

}
