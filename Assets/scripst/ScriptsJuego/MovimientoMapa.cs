using UnityEngine;
using UnityEngine.Tilemaps;

public class MovimientoMapa : MonoBehaviour
{
    public Tilemap tilemap;
    public float velocidadDesplazamiento = 2f;
    private Vector3 inicioPosicion;
    private MovimientoPersonaje jugador;

    void Start()
    {
        inicioPosicion = transform.position;
        jugador = GameObject.Find("Jugador").GetComponent<MovimientoPersonaje>();


    }

    void Update(){
         if(jugador.getVivo()){

    
        // Calcula la nueva posición del Tilemap
        Vector3 nuevaPosicion = transform.position + Vector3.right * velocidadDesplazamiento * Time.deltaTime;

        // Actualiza la posición del Tilemap
        transform.position = nuevaPosicion;

        // Si el Tilemap se ha desplazado más allá de su tamaño en X, restablece la posición
        if (transform.position.x - inicioPosicion.x > tilemap.size.x)
        {
            transform.position = inicioPosicion;
        }
    }else{
        
    }
    }
}
