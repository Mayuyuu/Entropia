using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{

	[SerializeField] Animator transitionAnim;

	public void PlayGame() 
	{
		SceneManager.LoadScene("Tutorial");
		 
	}


	public void QuitGame() 
	{
		Application.Quit();
	}

	public void NextLevel() 
	{
		StartCoroutine(LoadLevel());
	}

	IEnumerator LoadLevel() 
	{
		transitionAnim.SetTrigger("End");
		yield return new WaitForSeconds(1);
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
		//SceneManager.LoadScene("Platformer");
		transitionAnim.SetTrigger("Start");
	}
}
