using UnityEngine;

public class OscilacionDeEscala : MonoBehaviour
{
    [Header("Configuración de la Oscilación de Escala")]
    public float minScaleX = 0.5f; // Límite mínimo de escala en el eje X.
    public float maxScaleX = 2.0f; // Límite máximo de escala en el eje X.
    public float minScaleY = 0.5f; // Límite mínimo de escala en el eje Y.
    public float maxScaleY = 2.0f; // Límite máximo de escala en el eje Y.
    public float speed = 1f; // Velocidad de oscilación.

    private Vector2 currentScale;

    void Start()
    {
        currentScale = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    void Update()
    {
        // Calcula la escala actual en los ejes X e Y del objeto.
        float scaleX = Mathf.Lerp(minScaleX, maxScaleX, (Mathf.Sin(Time.time * speed) + 1f) / 2f);
        float scaleY = Mathf.Lerp(minScaleY, maxScaleY, (Mathf.Sin(Time.time * speed) + 1f) / 2f);

        // Aplica la nueva escala al objeto.
        transform.localScale = new Vector3(scaleX, scaleY, transform.localScale.z);
    }
}
