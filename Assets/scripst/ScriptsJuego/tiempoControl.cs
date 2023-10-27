using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TiempoControl : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public bool mostrarSinc = false;
    public double diferencia = 0;
    public Transform objeto; // Objeto cuya posición se va a rastrear

    private float tiempoTranscurrido = 0f; // Almacena el tiempo transcurrido desde el último mensaje mostrado

    void Update()
    {
        if (mostrarSinc && objeto != null) 
        {
            tiempoTranscurrido += Time.deltaTime; // Incrementa el tiempo transcurrido

            // Verifica si ha pasado un segundo y muestra la posición del objeto
           
                tiempoTranscurrido = 0f; // Reinicia el contador de tiempo
                int tiempoRedondeado = Mathf.RoundToInt((float)videoPlayer.time); // Redondea el tiempo al número entero más cercano
                Vector3 posicionObjeto = objeto.position; // Obtiene la posición del objeto
                Debug.Log("TIEMPO: " + tiempoRedondeado + " - POSICIÓN DEL OBJETO: " + (posicionObjeto.x + diferencia)); // Muestra el tiempo (redondeado a entero) y la posición del objeto
            
        }
    }
}
