using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para trabajar con SceneManager

public class ControladorMenuMuerte : MonoBehaviour
{
    private MovimientoPersonaje movimientoPersonaje; // Asigna el componente MovimientoPersonaje desde el Inspector
    public GameObject canvas; // Asigna el GameObject del canvas desde el Inspector

    void Start()
    {
        // Busca el GameObject del jugador por nombre
        GameObject jugadorObject = GameObject.Find("Jugador");

        // Asegúrate de que el GameObject del jugador y el componente MovimientoPersonaje existan
        if (jugadorObject != null)
        {
            movimientoPersonaje = jugadorObject.GetComponent<MovimientoPersonaje>();
        }
        else
        {
            Debug.LogError("No se encontró el GameObject del jugador con el nombre 'Jugador'.");
        }
    }

    void Update()
    {
        // Verifica si el jugador está vivo llamando al método getVivo
        bool jugadorVivo = movimientoPersonaje.getVivo();

        // Si el jugador no está vivo, activa el canvas, de lo contrario, desactívalo
        canvas.SetActive(!jugadorVivo);

        // Verifica si se presionó la tecla "R"
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Cargar la escena específica al presionar "R"
            SceneManager.LoadScene("Nivel1");
        }

        // Verifica si se presionó la tecla "Escape"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Cargar la escena específica al presionar "Escape"
            SceneManager.LoadScene("MenuInicio");
        }
    }
}
