using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public enum Velocidad { MuyLenta, Lenta, Normal, Rapida, UltraRapida }

    public float[] velocidades = { 3f, 5f, 10f, 15f, 20f }; // Valores de fuerza correspondientes a cada velocidad

    public Velocidad velocidad = Velocidad.Normal;

    private MovimientoPersonaje jugador; // La referencia al componente MovimientoPersonaje
    private MovimientoMapa mapa;

    private void Start()
    {
        // Buscar el objeto "Jugador" y obtener el componente MovimientoPersonaje
        jugador = GameObject.Find("Jugador").GetComponent<MovimientoPersonaje>();
        mapa = GameObject.Find("Mapa").GetComponent<MovimientoMapa>();
    }

    private void OnTriggerEnter2D(Collider2D  collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            Debug.Log("Colisión con el objeto 'Jugador' detectada");

            if (jugador != null)
            {
                float fuerza = ObtenerFuerza(velocidad);

                // Aplicar la fuerza al jugador
                jugador.fuerzaArriba = fuerza;
                jugador.fuerzaAbajo = -fuerza;
                mapa.velocidadDesplazamiento = -fuerza;
            }
        }
    }

    float ObtenerFuerza(Velocidad velocidad)
    {
        return velocidades[(int)velocidad];
    }
}
