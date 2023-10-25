using UnityEngine;
using System.Collections;

public class TriggerZoomCamera : MonoBehaviour
{
    public float zoomInDuration = 2.0f;
    public float zoomOutDuration = 2.0f; // Duración de la transición de deszoom
    public float targetSize = 5.0f;

    private Camera mainCamera;
    private float originalSize;
    private bool isZoomingIn = false;
    private bool isZoomingOut = false; // Nuevo indicador para la transición de deszoom
    private float zoomStartTime;
    private float zoomOutStartTime; // Nuevo tiempo de inicio de la transición de deszoom

    private void Start()
    {
        mainCamera = Camera.main;
        originalSize = mainCamera.orthographicSize;
    }

    private void Update()
    {
        if (isZoomingIn)
        {
            float timeElapsed = Time.time - zoomStartTime;
            float t = timeElapsed / zoomInDuration;

            mainCamera.orthographicSize = Mathf.Lerp(originalSize, targetSize, t);

            if (t >= 1.0f)
            {
                isZoomingIn = false;
            }
        }

        if (isZoomingOut)
        {
            float timeElapsed = Time.time - zoomOutStartTime;
            float t = timeElapsed / zoomOutDuration;

            mainCamera.orthographicSize = Mathf.Lerp(targetSize, originalSize, t);

            if (t >= 1.0f)
            {
                isZoomingOut = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            isZoomingIn = true;
            zoomStartTime = Time.time;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            isZoomingOut = true;
            zoomOutStartTime = Time.time;
        }
    }
}
