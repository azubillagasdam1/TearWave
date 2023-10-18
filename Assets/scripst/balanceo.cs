using System.Collections;
using UnityEngine;

public class PendulumRotation : MonoBehaviour
{
    [Header("Configuración del Péndulo")]
    public float minRotation = -20f; // Límite mínimo de rotación en grados.
    public float maxRotation = 20f; // Límite máximo de rotación en grados.
    public float speed = 1f; // Velocidad de oscilación del péndulo.

    private float currentRotation;

    void Start()
    {
        currentRotation = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        // Calcula el ángulo de rotación actual del objeto.
        currentRotation = transform.rotation.eulerAngles.z;

        // Calcula la nueva rotación usando una función sinusoidal.
        float newRotation = Mathf.Sin(Time.time * speed) * (maxRotation - minRotation) / 2f;
        newRotation = minRotation + newRotation;

        Quaternion newRotationQuaternion = Quaternion.Euler(0f, 0f, newRotation);
        transform.rotation = newRotationQuaternion;
    }
}
