using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float fuerzaArriba = 10f; // Fuerza hacia arriba
    public float fuerzaAbajo = -10f; // Fuerza hacia abajo
    private bool tocandoSuelo = false;
    private Rigidbody2D rb;
    private AudioSource audioSource; // Nuevo atributo para el AudioSource
      public ParticleSystem particulasMuerte;
    public bool vivo;

    public AudioClip audioMuerte; // Nuevo atributo para el audio de muerte

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vivo = true;

        // Agrega un AudioSource al objeto
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // Si se mantiene presionado el botón izquierdo del mouse
        if (Input.GetMouseButton(0))
        {
            arriba();
        }
        else
        {
            if (!tocandoSuelo)
            {
                abajo();
            }
            else
            {
                hechado();
            }
        }
    }

    void arriba()
    {
        rb.velocity = new Vector2(rb.velocity.x, fuerzaArriba);
        transform.rotation = Quaternion.Euler(0, 0, 45);
        tocandoSuelo = false;
    }

    void abajo()
    {
        rb.velocity = new Vector2(rb.velocity.x, fuerzaAbajo);
        transform.rotation = Quaternion.Euler(0, 0, -45);
    }

    void hechado()
    {
        rb.velocity = new Vector2(rb.velocity.x, fuerzaAbajo);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            muerte();
        }
        if (collision.gameObject.CompareTag("Bordes"))
        {
            tocandoSuelo = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstaculo"))
        {
            muerte();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bordes"))
        {
            // Establecer tocandoSuelo como false cuando ya no detecta colisiones con los bordes
        }
    }

    private void muerte()
    {
       
        if(vivo){
        // Reproducir el audio de muerte si está asignado
        if (audioMuerte != null)
        {
            audioSource.PlayOneShot(audioMuerte);
        }
         if (particulasMuerte != null)
        {
            Instantiate(particulasMuerte, transform.position, Quaternion.identity);
        }
        }
         vivo = false;

        // Destroy(gameObject);
    }

    public bool getVivo()
    {
        return vivo;
    }

    public float getFuerzaAbajo()
    {
        return fuerzaAbajo;
    }
}
