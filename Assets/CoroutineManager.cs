using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{

    private CameraZoom cameraZoom;
    private Shake shake;
    // Start is called before the first frame update
    void Start()
    {
        cameraZoom = GetComponent<CameraZoom>();
        shake = GetComponent<Shake>();
    }

   public void StartZoomCooldown()
    {
        StartCoroutine(cameraZoom.ZoomCooldown());
    }

    public void StartShaking()
    {
        StartCoroutine(shake.Shaking());
    }
}
