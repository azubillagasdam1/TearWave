using UnityEngine;

public class ControladorVelocidad : MonoBehaviour
{
    // Referencia al script movimientoPersonaje
    private MovimientoPersonaje jugador;

    // Aumento extra opcional
    public float aumentoExtra = 2.0f;

    private void Start()
    {
        // Obtén el componente movimientoPersonaje del GameObject llamado "Jugador"
        jugador = GameObject.Find("Jugador").GetComponent<MovimientoPersonaje>();

        // Asegúrate de que el script movimientoPersonaje esté asignado correctamente
        if (jugador == null)
        {
            Debug.LogError("El script movimientoPersonaje no está asignado en el Inspector.");
        }
    }

    void Update()
    {
        // Obtén la velocidad del script movimientoPersonaje
        float velocidad = jugador.getFuerzaAbajo();

        // Añade el aumento extra a la velocidad si es mayor que cero
        if (aumentoExtra > 0f)
        {
            velocidad -= aumentoExtra;
        }

        // Obtén el componente de sistema de partículas
        ParticleSystem sistemaParticulas = GetComponent<ParticleSystem>();

        // Obtén el módulo Velocity Over Lifetime
        var velocityOverLifetimeModule = sistemaParticulas.velocityOverLifetime;

        // Modifica la velocidad en el eje X según el parámetro de velocidad del script movimientoPersonaje
        velocityOverLifetimeModule.x = new ParticleSystem.MinMaxCurve(velocidad);
    }
}
