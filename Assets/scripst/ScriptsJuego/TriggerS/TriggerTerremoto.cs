using UnityEngine;

public class TriggerTerremoto : MonoBehaviour
{
    public float magnitude = 0.1f;

    private Camera mainCamera;
    private bool jugadorDentro = false;

    private void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Camera.main no encontrada. Asegúrate de que haya una cámara principal en la escena.");
        }
    }

    private void Update()
    {
        if (jugadorDentro && mainCamera != null)
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
            if (mainCamera != null)
            {
                mainCamera.transform.position = new Vector3(0, 0, -10);
            }
        }
    }

    private void ShakeCamera()
    {
        if (mainCamera != null)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            mainCamera.transform.localPosition = new Vector3(xOffset, yOffset, mainCamera.transform.localPosition.z);
        }
    }
}
