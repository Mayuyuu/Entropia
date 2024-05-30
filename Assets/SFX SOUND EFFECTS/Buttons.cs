using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{

    private AudioManager audioManager;

    public void Start()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}

   public void SFXButtons()
	{
		AudioManager._Instance.PlaySFX(audioManager.ButtonUi);
	}
    
}
