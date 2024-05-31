using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameCinematic : MonoBehaviour
{

    [SerializeField] Animator transitionAnim;
    public bool playerIsClose;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            
            // StartCoroutine(LastCinematic());
            SceneManager.LoadScene("EndCinematic");
        }
    }


    // IEnumerator LastCinematic()
    // {
        
		
    //     AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("EndCinematic");
    //     // transitionAnim.SetTrigger("End");
    //     // while (!asyncLoad.isDone)
    //     // {
    //     //     yield return null;
    //     // }
    //     // transitionAnim.SetTrigger("Start");
    // }


}

