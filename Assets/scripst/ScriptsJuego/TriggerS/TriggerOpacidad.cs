using UnityEngine;

public class CambioBrillo : MonoBehaviour
{
    public Camera mainCamera; // Asigna tu cámara 2D a través del Inspector
    public float brilloNormal = 1.0f; // Brillo normal de la cámara
    public float brilloOscuro = 0.5f; // Brillo cuando el jugador entra en el trigger

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            Debug.Log("Entered");
            CambiarBrillo(brilloOscuro);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            Debug.Log("Exited");
            CambiarBrillo(brilloNormal);
        }
    }

    private void CambiarBrillo(float brillo)
    {
        Color nuevaColor = mainCamera.backgroundColor;
        nuevaColor.r *= brillo;
        nuevaColor.g *= brillo;
        nuevaColor.b *= brillo;
        mainCamera.backgroundColor = nuevaColor;
    }
}
