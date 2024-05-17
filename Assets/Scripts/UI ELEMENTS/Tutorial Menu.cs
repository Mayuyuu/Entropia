using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
   [SerializeField] Animator transitionAnim;
    public bool playerIsClose;



//------------------------------------------PASSAGE A AUTRE SCENE
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            StartCoroutine(PlatformerLevel());
        }
    }


    IEnumerator PlatformerLevel()
    {
        
		
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Platformer");
        transitionAnim.SetTrigger("End");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        transitionAnim.SetTrigger("Start");
    }
}
