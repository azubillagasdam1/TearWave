using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float fuerzaArriba = 10f; // Fuerza hacia arriba
    public float fuerzaAbajo = -10f; // Fuerza hacia abajo
    private Rigidbody2D rb;
    private bool tocandoSuelo;
    public bool vivo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vivo = true;
        tocandoSuelo = false;
    }

    void Update()
    {
        // Si se mantiene presionado el botón izquierdo del mouse
       if(!tocandoSuelo){ 
        if (Input.GetMouseButton(0)){
            AplicarFuerzaArriba();
        }
      
        else  {
            AplicarFuerzaAbajo();
        }
    }else{
        if (Input.GetMouseButton(0))
        {
            AplicarFuerzaArriba();
            tocandoSuelo = false;
        }else{
           
            AplicarFuerzaAbajo();
        }
    }
    }

    void AplicarFuerzaArriba()
    {
        rb.velocity = new Vector2(rb.velocity.x, fuerzaArriba);
        // Cambiar la rotación en el eje Z a 45 grados
        transform.rotation = Quaternion.Euler(0, 0, 45);
    }

    void AplicarFuerzaAbajo()
    {
        rb.velocity = new Vector2(rb.velocity.x, fuerzaAbajo);
        // Cambiar la rotación en el eje Z a -45 grados
        transform.rotation = Quaternion.Euler(0, 0, -45);
    }

    void AnularFuerzas()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        // Restablecer la rotación en el eje Z a 0 grados
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
            // Elimina el personaje si colisiona con el Tilemap
            tocandoSuelo = true;
        } else{
            tocandoSuelo = false;
        }
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
    if (collision.gameObject.CompareTag("Obstaculo"))
        {
            // Elimina el personaje si colisiona con el Tilemap
            Destroy(gameObject);
            vivo = false;
        }
        if (collision.gameObject.CompareTag("Bordes"))
        {
            // Elimina el personaje si colisiona con el Tilemap
            tocandoSuelo = true;
        } else{
            tocandoSuelo = false;
        }

    }
    public bool getVivo(){
        return vivo;
    }


}
