using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavityDetector : MonoBehaviour
{
    //public GameObject gameobject;

    public void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(Disappear());
        }
    }

    private IEnumerator Disappear()
    {
                float timer = 0f;
                while(timer <= 1) 
              {
                    timer += Time.deltaTime / 1
                    ;  
                    this.gameObject.GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, Mathf.Lerp(255, 0, timer)); 
                    Debug.Log(timer);
                    yield return null;
               }
    }

}
