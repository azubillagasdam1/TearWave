using UnityEngine;

public class TriggerRotacionCamara : MonoBehaviour
{
    public float rotationDuration = 2.0f;
    public float rotationSpeed = 180.0f;
    public float zoomDuration = 1.0f;
    public float zoomAmount = 0.5f;

    private Camera mainCamera;
    private Transform jugador;
    private Vector3 initialCameraPosition;
    private float initialOrthographicSize;
    private bool isTriggered = false;
    private bool isZooming = false;

    private void Start()
    {
        mainCamera = Camera.main;
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;
        initialCameraPosition = mainCamera.transform.position;
        initialOrthographicSize = mainCamera.orthographicSize;
    }

    private void Update()
    {
        if (isTriggered)
        {
            float angleToRotate = rotationSpeed * Time.deltaTime;
            mainCamera.transform.Rotate(Vector3.forward, angleToRotate);
            rotationDuration -= Time.deltaTime;

            if (!isZooming && rotationDuration <= zoomDuration)
            {
                isZooming = true;

                float startSize = mainCamera.orthographicSize;
                float targetSize = startSize * zoomAmount;
                Vector3 targetCameraPosition = new Vector3(jugador.position.x, jugador.position.y, mainCamera.transform.position.z);
                float elapsedTime = 0;
                float zoomHalfDuration = zoomDuration / 2;

                while (elapsedTime < zoomHalfDuration)
                {
                    mainCamera.orthographicSize = Mathf.Lerp(startSize, targetSize, (elapsedTime / zoomHalfDuration));
                    mainCamera.transform.position = Vector3.Lerp(initialCameraPosition, targetCameraPosition, (elapsedTime / zoomHalfDuration));
                    elapsedTime += Time.deltaTime;
                }

                mainCamera.orthographicSize = targetSize;
                mainCamera.transform.position = targetCameraPosition;

                while (elapsedTime > 0)
                {
                    mainCamera.orthographicSize = Mathf.Lerp(targetSize, startSize, (elapsedTime / zoomHalfDuration));
                    mainCamera.transform.position = Vector3.Lerp(targetCameraPosition, initialCameraPosition, (elapsedTime / zoomHalfDuration));
                    elapsedTime -= Time.deltaTime;
                }

                mainCamera.orthographicSize = startSize;
                mainCamera.transform.position = initialCameraPosition;
                isZooming = false;
                
            }

            if (rotationDuration <= 0)
            {
                isTriggered = false;
                 mainCamera.transform.rotation = Quaternion.Euler(0, 0, 0); // Coloca la rotación Z a 0 al finalizar la rotación.
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisión con el objeto 'Jugador' detectada");
        if (collision.CompareTag("Jugador"))
        {
            isTriggered = true;
        }
    }
}
