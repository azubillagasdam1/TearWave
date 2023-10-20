using UnityEngine;
using System.Collections;


public class CameraRotationTrigger : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // Velocidad de rotación de la cámara

    private Camera mainCamera; // La referencia a la cámara principal

    private void Start()
    {
        // Buscar la cámara principal
        mainCamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            Debug.Log("Colisión con el objeto 'Jugador' detectada");

            if (mainCamera != null)
            {
                // Rotar la cámara 360 grados
                StartCoroutine(RotateCamera360());
            }
        }
    }

    IEnumerator RotateCamera360()
    {
        float elapsedTime = 0;
        Quaternion initialRotation = mainCamera.transform.rotation;
        Quaternion targetRotation = initialRotation * Quaternion.Euler(0, 0, 360);

        while (elapsedTime < 1.0f)
        {
            elapsedTime += Time.deltaTime * rotationSpeed;
            mainCamera.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime);
            yield return null;
        }

        // Asegurarse de que la rotación sea exactamente 360 grados
        mainCamera.transform.rotation = targetRotation;
    }
}
