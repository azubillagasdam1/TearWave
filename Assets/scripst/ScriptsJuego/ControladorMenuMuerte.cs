using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorMenuMuerte : MonoBehaviour
{
    private MovimientoPersonaje movimientoPersonaje;
    public GameObject canvas;
    private CanvasGroup canvasGroup;
    public float velocidadTransicion = 2f; // Puedes ajustar la velocidad de transición según tus preferencias

    void Start()
    {
        GameObject jugadorObject = GameObject.Find("Jugador");

        if (jugadorObject != null)
        {
            movimientoPersonaje = jugadorObject.GetComponent<MovimientoPersonaje>();
        }
        else
        {
            Debug.LogError("No se encontró el GameObject del jugador con el nombre 'Jugador'.");
        }

        // Obtén el componente CanvasGroup del canvas
        canvasGroup = canvas.GetComponent<CanvasGroup>();

        // Asegúrate de que el CanvasGroup no sea nulo
        if (canvasGroup == null)
        {
            Debug.LogError("No se encontró el componente CanvasGroup en el GameObject del canvas.");
        }

        // Inicializa la opacidad a cero al inicio
        canvasGroup.alpha = 0f;
    }

    void Update()
    {
        bool jugadorVivo = movimientoPersonaje.getVivo();

        // Aplica una transición gradual de opacidad
        float objetivoOpacidad = jugadorVivo ? 0f : 1f;
        canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, objetivoOpacidad, velocidadTransicion * Time.deltaTime);

        // Si el jugador no está vivo, activa el canvas, de lo contrario, desactívalo
        canvas.SetActive(!jugadorVivo);

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Nivel1");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuInicio");
        }
    }
}
