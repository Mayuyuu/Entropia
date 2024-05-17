using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

//public Animator camAnim;

    public bool IsShaking = false;
    public float duration =0.5f;


    public void StartShaking()
    {
        IsShaking = true;
        StartCoroutine(Shaking());
    }

    public IEnumerator Shaking()
    {
        Vector3 startPosition= transform.position;
        float elapsedTime =0f;


        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            transform.position =startPosition+ Random.insideUnitSphere;
            yield return null;
        }

        transform.position = startPosition;
        IsShaking = false;
    }

    //-----------------------------------------------------A METTRE AILLEURS STP
//    public float speed;
//    public GameObject effect;


//    private Shake shake;

//  void Start()
//     {
//         shake= GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
//     }
//     // Update is called once per frame
//     void Update()
//     {
//         transform.Translate(Vector2.right *speed* Time.deltaTime);
//     }

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         shake.ScreenShake();
//         Destroy(other.gameObject);
//         Instantiate(effect,transform.position, Quaternion.identity);
//         Destroy(gameObject);
//     }
}
