using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    Vector2 checkpointPos;
    Player playercp;
    private object collision;

	private void Start() 
    {
		
        checkpointPos = transform.position;
	}

	private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            playercp = GameManager.Instance.getPlayer();
            playercp.UpdateCheckPoint(transform.position); //permet d'actualiser sa position
            //lancer anim SEt trigger animator
        }
        
    }


}