using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float fuerzaArriba = 10f; // Fuerza hacia arriba
    public float fuerzaAbajo = -10f; // Fuerza hacia abajo
    private bool tocandoSuelo = false;
    private Rigidbody2D rb;

    public bool vivo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vivo = true;
    }

    void Update()
    {
        // Si se mantiene presionado el botón izquierdo del mouse
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Subiendo");
            arriba();
        }
        else
        {
            if (!tocandoSuelo)
            {
                Debug.Log("Bajando");
                abajo();
            }
            else
            {
                Debug.Log("Hechado");
                hechado();
            }
        }
    }


    void arriba()
    {
  rb.velocity = new Vector2(rb.velocity.x, fuerzaArriba);
        // Cambiar la rotación en el eje Z a -45 grados
        transform.rotation = Quaternion.Euler(0, 0, 45);
         tocandoSuelo = false;
    }

    void abajo()
    {
        rb.velocity = new Vector2(rb.velocity.x, fuerzaAbajo);
        // Cambiar la rotación en el eje Z a -45 grados
        transform.rotation = Quaternion.Euler(0, 0, -45);
    }

    void hechado()
    {
        rb.velocity = new Vector2(rb.velocity.x, fuerzaAbajo);

        // Cambiar la rotación en el eje Z a 0 grados
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            // Elimina el personaje si colisiona con el Tilemap
            Destroy(gameObject);
            vivo = false;
        }
        if (collision.gameObject.CompareTag("Bordes"))
        {
            // Establecer tocandoSuelo como false cuando ya no detecta colisiones con los bordes
            tocandoSuelo = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bordes"))
        {
            // Establecer tocandoSuelo como false cuando ya no detecta colisiones con los bordes
           
        }
    }

    public bool getVivo()
    {
        return vivo;
    }
}