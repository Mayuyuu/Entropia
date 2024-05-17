using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform posA, posB;
    public float speed;
    Vector3 targetPos;

    // Player movementController;
    // Rigidbody2D rb;
    // Vector3 moveDirection;

    // private void Awake()
    // {
    //     movementController =GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    //     rb = GetComponent<Rigidbody2D>();
    // }
    private void Start()
    {
        targetPos= posB.position;
    //     DirectionCalculate();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.05f)
        {
            targetPos = posB.position;
            // DirectionCalculate();
        }

        if (Vector2.Distance(transform.position, posB.position) < 0.05f)
        {
            targetPos = posA.position;
            // DirectionCalculate();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    // private void FixedUpdate()
    // {
    //     rb.velocity=moveDirection * speed;
    // }

    // void DirectionCalculate()
    // {
    //     moveDirection = (targetPos - transform.position).normalized;
    // }
//     private void OnTriggerEnter2D(Collider2D collider)
//     {
//         if (collider.CompareTag("Player"))
//         {
//             // movementController.isOnPlatform = true;
//             // movementController.platformRb = rb;
//             collider.transform.parent = this.transform;

//         }
//     }

//     private void OnTriggerExit2D(Collider2D collider)
//     {
//         if (collider.CompareTag("Player"))
//         {
//             // movementController.isOnPlatform =false;
//             collider.transform.parent = null;
//         }
//     }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(transform,true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent= null;
        }
    }

 }
