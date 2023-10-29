using UnityEngine;
using System.Collections.Generic;

public class Estela : MonoBehaviour
{
    public GameObject jugador; // Debes asignar el objeto "Jugador" en el Inspector
    public GameObject objetoPrefab; // El prefab del objeto que deseas generar
    public GameObject objetoPadre; // Debes asignar el objeto al que deseas que sea hijo
    public float tiempoEntreGeneracion = 0.5f; // Tiempo en segundos entre generaciones
    public int limiteObjetos = 20; // Límite de objetos generados

    private float tiempoUltimaGeneracion;
    private List<GameObject> objetosGenerados = new List<GameObject>();

    private void Start()
    {
        tiempoUltimaGeneracion = Time.time;
    }

    private void Update()
    {
        if (jugador != null && Time.time - tiempoUltimaGeneracion >= tiempoEntreGeneracion)
        {
            // Obtén las coordenadas del jugador
            Vector2 posicionJugador = jugador.transform.position;

            // Crea un nuevo GameObject utilizando el prefab y establece su posición
            GameObject nuevoObjeto = Instantiate(objetoPrefab, posicionJugador, Quaternion.identity);

            // Establece el nuevo objeto como hijo del objeto deseado
            if (objetoPadre != null)
            {
                nuevoObjeto.transform.parent = objetoPadre.transform;
            }

            // Puedes personalizar el nuevo objeto aquí si lo deseas

            // Agrega el nuevo objeto a la lista de objetos generados
            objetosGenerados.Add(nuevoObjeto);

            // Verifica si se ha superado el límite de objetos
            if (objetosGenerados.Count > limiteObjetos)
            {
                // Destruye el objeto más antiguo en la lista
                Destroy(objetosGenerados[0]);
                objetosGenerados.RemoveAt(0);
            }

            // Actualiza el tiempo de la última generación
            tiempoUltimaGeneracion = Time.time;
        }
    }
}
