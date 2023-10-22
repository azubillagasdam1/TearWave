using UnityEngine;

public class TriggerRotacionCamara : MonoBehaviour
{
    public float rotationDuration = 2.0f;
    public float rotationSpeed = 180.0f;

    private Camera mainCamera;
    private Transform jugador;
    private bool isTriggered = false;

    private void Start()
    {
        mainCamera = Camera.main;
        jugador = GameObject.FindGameObjectWithTag("Jugador").transform;
    }

    private void Update()
    {
        if (isTriggered)
        {
            float angleToRotate = rotationSpeed * Time.deltaTime;
            mainCamera.transform.Rotate(Vector3.forward, angleToRotate);
            rotationDuration -= Time.deltaTime;

            if (rotationDuration <= 0)
            {
                isTriggered = false;
             
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
