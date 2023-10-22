using UnityEngine;
using System.Collections;

public class TriggerTerremoto : MonoBehaviour
{
    public float magnitude = 0.1f;

    private Camera mainCamera;
    private bool jugadorDentro = false;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (jugadorDentro)
        {
            ShakeCamera();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisión con el objeto 'Jugador' detectada");
        if (collision.CompareTag("Jugador"))
        {
            jugadorDentro = true;
            ShakeCamera();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Colisión de salida con el objeto 'Jugador' detectada");
        if (collision.CompareTag("Jugador"))
        {
            jugadorDentro = false;
             mainCamera.transform.position = new Vector3(0, 0, -10);
        }
    }

    private void ShakeCamera()
    {
        float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
        float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;
        mainCamera.transform.localPosition = new Vector3(xOffset, yOffset, mainCamera.transform.localPosition.z);
    }
}
