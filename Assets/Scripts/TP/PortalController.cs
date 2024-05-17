using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{

    public Transform destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            if (Vector2.Distance(player.transform.position, transform.position) >0.3f)
            {
                player.transform.position = destination.transform.position;
            }
            
        }
        
    }
}
