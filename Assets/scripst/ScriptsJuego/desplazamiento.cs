using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilacionPrensa : MonoBehaviour
{
    public Vector2 desplazamiento; // Desplazamiento en unidades X e Y
    public float desplazamientoRotacionZ = 0.0f; // Desplazamiento de rotación en Z
    public float velocidad = 1.0f;  // Velocidad de oscilación
    public bool InvertirRotación = false; // Nuevo booleano para invertir la rotación

    private Vector2 posicionInicial; // Posición inicial de la prensa
    private Quaternion rotacionInicial; // Rotación inicial de la prensa
    private Vector2 objetivoPosicion; // La posición a la que se dirige actualmente
    private float objetivoRotacionZ; // El valor de rotación Z al que se dirige actualmente

    void Start()
    {
        posicionInicial = transform.position; // Tomamos la posición inicial del GameObject
        rotacionInicial = transform.rotation; // Tomamos la rotación inicial del GameObject
        objetivoPosicion = posicionInicial + desplazamiento; // Comenzamos moviéndonos hacia la posición final
        objetivoRotacionZ = rotacionInicial.eulerAngles.z + desplazamientoRotacionZ;
    }

    void Update()
    {
        if (desplazamiento != Vector2.zero) // Verifica si el desplazamiento no es igual a cero
        {
            // Mueve la prensa hacia el objetivo de posición
            transform.position = Vector2.MoveTowards(transform.position, objetivoPosicion, velocidad * Time.deltaTime);
        }

        // Rota la prensa hacia el objetivo de rotación en Z
        if (InvertirRotación) // Comprueba si se debe invertir la rotación
        {
            float nuevaRotacionZ = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.z, -objetivoRotacionZ, velocidad * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, nuevaRotacionZ);
        }
        else
        {
            float nuevaRotacionZ = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.z, objetivoRotacionZ, velocidad * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, nuevaRotacionZ);
        }

        // Verifica si ha llegado al objetivo de posición
        if ((Vector2)transform.position == objetivoPosicion)
        {
            // Cambia la dirección de movimiento de posición
            if (objetivoPosicion == (posicionInicial + desplazamiento))
                objetivoPosicion = posicionInicial;
            else
                objetivoPosicion = posicionInicial + desplazamiento;
        }

        // Verifica si ha llegado al objetivo de rotación en Z
        if (Mathf.Approximately(transform.rotation.eulerAngles.z, objetivoRotacionZ))
        {
            // Cambia la dirección de movimiento de rotación en Z
            if (objetivoRotacionZ == (rotacionInicial.eulerAngles.z + desplazamientoRotacionZ))
                objetivoRotacionZ = rotacionInicial.eulerAngles.z;
            else
                objetivoRotacionZ = rotacionInicial.eulerAngles.z + desplazamientoRotacionZ;
        }
    }
}
