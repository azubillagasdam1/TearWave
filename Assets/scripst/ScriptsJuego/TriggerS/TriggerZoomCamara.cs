using UnityEngine;
using System.Collections;

public class TriggerZoomCamera : MonoBehaviour
{
    public float zoomInDuration = 2.0f;
    public float targetSize = 5.0f;

    private Camera mainCamera;
    private float originalSize;
    private bool isZooming = false;
    private float zoomStartTime;

    private void Start()
    {
        mainCamera = Camera.main;
        originalSize = mainCamera.orthographicSize;
    }

    private void Update()
    {
        if (isZooming)
        {
            float timeElapsed = Time.time - zoomStartTime;
            float t = timeElapsed / zoomInDuration;

            mainCamera.orthographicSize = Mathf.Lerp(originalSize, targetSize, t);

            if (t >= 1.0f)
            {
                isZooming = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            isZooming = true;
            zoomStartTime = Time.time;
        }
    }
}
