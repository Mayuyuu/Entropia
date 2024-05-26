using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qUITGAME : MonoBehaviour
{
   public void QuitGame() 
	{
		Application.Quit();
		// AudioManager._Instance.PlaySFX(audioManager.ButtonUi);
	}
}
