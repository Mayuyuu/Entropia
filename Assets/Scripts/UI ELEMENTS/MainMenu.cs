using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	private AudioManager audioManager;
	[SerializeField] Animator transitionAnim;


	public void Start()
	{
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
	}
	public void PlayGame() 
	{
		SceneManager.LoadScene("CUTSCENE 01");
		AudioManager._Instance.PlaySFX(audioManager.ButtonUi);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
		 
	}


	public void QuitGame() 
	{
		Application.Quit();
		// AudioManager._Instance.PlaySFX(audioManager.ButtonUi);
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
	public void SFXButtons()
	{
		AudioManager._Instance.PlaySFX(audioManager.ButtonUi);
	}
}
