using UnityEngine;

public class ControlOpacidad : MonoBehaviour
{
    private SpriteRenderer objetoRenderer;
    private Color colorOriginal;
    private bool jugadorDentro = false;
    public float opacity = 0f;
    public float fadeInSpeed = 2.0f;
    public float fadeOutSpeed = 2.0f;

    public GameObject objetoConOpacidad; // Objeto cuya opacidad queremos controlar

    private void Start()
    {
        objetoRenderer = objetoConOpacidad.GetComponent<SpriteRenderer>();
        colorOriginal = objetoRenderer.color;
        objetoConOpacidad.SetActive(false); // Desactiva el objeto al inicio
    }

    private void Update()
    {
        if (jugadorDentro)
        {
            // Activa el objeto al entrar
            objetoConOpacidad.SetActive(true);
            
            // Aplica un efecto de FadeIn
            Color nuevoColor = objetoRenderer.color;
            nuevoColor.a = Mathf.MoveTowards(nuevoColor.a, opacity, Time.deltaTime * fadeInSpeed);
            objetoRenderer.color = nuevoColor;
        }
        else
        {
            // Aplica un efecto de FadeOut
            Color nuevoColor = objetoRenderer.color;
            nuevoColor.a = Mathf.MoveTowards(nuevoColor.a, colorOriginal.a, Time.deltaTime * fadeOutSpeed);
            objetoRenderer.color = nuevoColor;

            // Desactiva el objeto al salir
            if (nuevoColor.a <= colorOriginal.a)
            {
                objetoConOpacidad.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisión con el objeto 'Jugador' detectada");
        if (collision.CompareTag("Jugador"))
        {
            jugadorDentro = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Colisión de salida con el objeto 'Jugador' detectada");
        if (collision.CompareTag("Jugador"))
        {
            jugadorDentro = false;
        }
    }
}
