using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    private float zoom;
    private float zoomMultiplier =4f;
    private float minZoom = 11f;
    private float maxZoom = 20f;

    private float velocity = 0f;
    private float smoothTime = 0.25f;

    [SerializeField] private float ZoomCooldownTime = 5f;

    private bool isZoomReady = true;

    [SerializeField] private Camera cam;

    [SerializeField] public Image cooldownImage;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        zoom = cam.orthographicSize;
        cooldownImage.fillAmount =1;
        // cooldownImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if ( Input.GetKeyDown("c") && isZoomReady)
        {
            isZoomReady = false;
            // anim = GetComponent<Animator>();
            StartCoroutine(ZoomCooldown());
        }

        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime); //maj la cam pour l 'effet smooth


        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            zoom = minZoom;
        }
        
    }
    
    public IEnumerator ZoomCooldown()
    {
        zoom = maxZoom;
        cooldownImage.fillAmount =0;
        cooldownImage.enabled = true;
        // anim.Play("C key");
        float elapsedTime =0f;
        while (elapsedTime < ZoomCooldownTime)
        {
            elapsedTime += Time.deltaTime;
            cooldownImage.fillAmount = (elapsedTime / ZoomCooldownTime);
            yield return null;
        }

        cooldownImage.fillAmount = 1;
        //cooldownImage.enabled = false;
        
        //yield return new WaitForSeconds(ZoomCooldownTime);
        isZoomReady = true;

    }



}

    