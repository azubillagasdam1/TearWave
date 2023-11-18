using UnityEngine;

public class TriggerSeguirJugador : MonoBehaviour
{
    private Camera mainCamera;
    private Transform jugador;
    private bool seguir = false; // Variable privada para habilitar o deshabilitar el seguimiento.
    public ModoSeguimiento modoSeguimiento = ModoSeguimiento.SeguimientoX; // Enum para seleccionar el modo de seguimiento.

    private float camX;
    private float camY;
    private float jugadorX;
    private float jugadorY;

    public enum ModoSeguimiento
    {
        SeguimientoX,
        SeguimientoY,
        
        SeguimientoXY
    }

    private void Start()
    {
        mainCamera = Camera.main;
        jugador = GameObject.FindGameObjectWithTag("Jugador")?.transform; // Verifica si el jugador es nulo.
    }

    private void Update()
    {
        camX = mainCamera.transform.position.x;
        camY = mainCamera.transform.position.y;

        
            jugadorX = jugador.position.x;
            jugadorY = jugador.position.y;

            if (seguir)
            {
                float newX = camX;
                float newY = camY;

               if(modoSeguimiento == ModoSeguimiento.SeguimientoX)
                {
                      newX = Mathf.Lerp(camX, jugadorX, Time.deltaTime);
                } else if (modoSeguimiento == ModoSeguimiento.SeguimientoY)
                {
                    // Si el modo de seguimiento es "SeguimientoY", centra en el eje Y.
                    newY = Mathf.Lerp(camY, jugadorY, Time.deltaTime);
                }
                else if (modoSeguimiento == ModoSeguimiento.SeguimientoXY)
                {
                    // Interpola suavemente la posición de la cámara en ambos ejes hacia la del jugador.
                    newX = Mathf.Lerp(camX, jugadorX, Time.deltaTime);
                    newY = Mathf.Lerp(camY, jugadorY, Time.deltaTime);
                }

                // Establece la nueva posición de la cámara.
                mainCamera.transform.position = new Vector3(newX, newY, mainCamera.transform.position.z);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisión con el objeto 'Jugador' detectada");
        if (collision.CompareTag("Jugador"))
        {
            seguir = true; // Activa el seguimiento cuando ocurre la colisión con el jugador.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            seguir = false; // Desactiva el seguimiento cuando el jugador sale del trigger.
            mainCamera.transform.position = new Vector3(0, 0, -10);
        }
    }
}
