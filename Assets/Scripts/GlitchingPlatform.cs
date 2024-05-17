using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlitchingPlatform : MonoBehaviour
{


    public float durationTransition = 2f;
    private Material material;
    private float timerTransition =0f;
    private Renderer objRenderer;

    


    private Vector3 originalSize;
    private Vector3 targetSize = new Vector3(2f,2f,2f);

    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
        }

        //objRenderer = GetComponent<BoxCollider>();



        if (objRenderer != null)
        {
            originalSize = objRenderer.bounds.size;
        }
    }

    // Update is called once per frame


    //--------------------------------PERMET DE GERER L ALPHA ET LE TIMER
    void Update()
    {
        if(material !=null && timerTransition < durationTransition)
        {
            timerTransition += Time.deltaTime;
            float alpha = Mathf.Clamp01(timerTransition / durationTransition);
            material.SetFloat("_Alpha", alpha);
            UpdateCollider(alpha);
        }
    }



    void UpdateCollider(float alpha)
    {
        if (objRenderer != null)
        {
            Vector3 currentSize = Vector3.Lerp(originalSize, targetSize, alpha);
            Vector3 scale = transform.localScale;
            scale.x = currentSize.x / originalSize.x;
            transform.localScale = scale;
        }
    }
}
