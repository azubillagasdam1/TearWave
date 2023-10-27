using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Midgard : MonoBehaviour
{
    public Vector2 posicionInicial; // Posición inicial de la prensa
    public Vector2 posicionFinal;   // Posición final de la prensa
    public float velocidad = 1.0f;  // Velocidad de oscilación

    private Vector2 objetivo; // La posición a la que se dirige actualmente

    void Start()
    {
        objetivo = posicionFinal; // Comenzamos moviéndonos hacia la posición final
    }

    void Update()
    {
        // Mueve la prensa hacia el objetivo
        transform.position = Vector2.MoveTowards(transform.position, objetivo, velocidad * Time.deltaTime);

        // Si llegamos al objetivo, cambiamos la dirección de movimiento
        if ((Vector2)transform.position == objetivo)
        {
            if (objetivo == posicionFinal)
                objetivo = posicionInicial;
            else
                objetivo = posicionFinal;
        }
    }
}
