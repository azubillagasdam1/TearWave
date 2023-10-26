using UnityEngine;

public class RotacionContinua : MonoBehaviour
{
    public float velocidadRotacion = 100.0f; // La velocidad de rotación deseada.

    private void Update()
    {
        // Rotamos el GameObject en el eje Z (2D) a la velocidad especificada.
        transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);
    }
}
