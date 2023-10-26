using UnityEngine;
using System.Collections; 
public class CambioColorEnTrigger : MonoBehaviour
{
    public float opacidad;
    public GameObject objetoACambiarColor;
    public float transicionSpeed = 2.0f;
    private SpriteRenderer spriteRenderer;
    private Color colorInicial;
    private Color colorDeseado;
    private bool dentro = false;
    private float tiempoTransicion = 5;

    private void Start()
{
    spriteRenderer = objetoACambiarColor.GetComponent<SpriteRenderer>();
    objetoACambiarColor.SetActive(true); 
}

    private void Update()
    {
        if (dentro)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, colorDeseado, Time.deltaTime * transicionSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            actualizarColores();
            dentro = true;
            StartCoroutine(ResetDentroAfterDelay(tiempoTransicion));
        }
    }

    private void actualizarColores()
    {
        colorInicial = spriteRenderer.color;
        colorDeseado = new Color(colorInicial.r, colorInicial.g, colorInicial.r, opacidad);
        spriteRenderer.color = colorInicial;
    }

    private IEnumerator ResetDentroAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        dentro = false;
    }
}
