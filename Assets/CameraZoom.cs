using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    // Start is called before the first frame update
    void Start()
    {
        zoom = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {

        if ( Input.GetKeyDown("c") && isZoomReady)
        {
            isZoomReady = false;
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
        
        yield return new WaitForSeconds(ZoomCooldownTime);
        isZoomReady = true;

    }



}

    