using UnityEngine;

public class CargaGiro : MonoBehaviour
{
    public float velocidadRotacion = 5f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Obtener la rotación actual del GameObject
        Vector3 rotacionActual = transform.eulerAngles;

        // Modificar la rotación Z
        rotacionActual.z += velocidadRotacion * Time.deltaTime;

        // Aplicar la nueva rotación al GameObject
        transform.eulerAngles = rotacionActual;
    }
}
