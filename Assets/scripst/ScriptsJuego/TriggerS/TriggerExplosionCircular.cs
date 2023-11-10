using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public enum ExplosionType
    {
        ExplosionCircular,
        ExplosionLineal,
        ExplosionIzquierda
    }

    public GameObject triangularPrefab;
    public int numberOfObjects = 10;
    public float explosionForce = 10f;
    public List<GameObject> explosionOrigins = new List<GameObject>(); // Lista de objetos que lanzan la explosión
    public ExplosionType explosionType = ExplosionType.ExplosionCircular;

    private bool jugadorDentro;
    private bool explosionEjecutada;

    void Start()
    {
        jugadorDentro = false;
        explosionEjecutada = false;
    }

    void Update()
{
    if (jugadorDentro && !explosionEjecutada)
    {
        if (explosionType == ExplosionType.ExplosionCircular)
        {
            foreach (var origin in explosionOrigins)
            {
                CreateExplosion1(origin);
            }
        }
        else if (explosionType == ExplosionType.ExplosionLineal)
        {
            CreateExplosion2(explosionOrigins);
        }
        else if (explosionType == ExplosionType.ExplosionIzquierda)
        {
            CreateExplosion3(explosionOrigins);
        }
        explosionEjecutada = true;
    }
}


    void CreateExplosion1(GameObject origin)
{
    for (int i = 0; i < numberOfObjects; i++)
    {
        float angle = i * (360f / numberOfObjects);
        Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.up;

        GameObject triangular = Instantiate(triangularPrefab, origin.transform.position, Quaternion.identity);
        Rigidbody2D rb = triangular.GetComponent<Rigidbody2D>();

        rb.AddForce(direction * explosionForce, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-180f, 180f));

        // Destruye el objeto después de 5 segundos
        Destroy(triangular, 5.0f);
    }
}

void CreateExplosion2(List<GameObject> origins)
{
    GameObject jugador = GameObject.FindGameObjectWithTag("Jugador");
    if (jugador != null)
    {
        Vector2 jugadorPosition = jugador.transform.position;
        foreach (var origin in origins)
        {
            Vector2 explosionOriginPosition = origin.transform.position;
            Vector2 direction = (jugadorPosition - explosionOriginPosition).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            GameObject bullet = Instantiate(triangularPrefab, explosionOriginPosition, rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.AddForce(direction * explosionForce, ForceMode2D.Impulse);
            rb.AddTorque(Random.Range(-180f, 180f));

            // Destruye el objeto después de 5 segundos
            Destroy(bullet, 5.0f);
        }
    }
}

void CreateExplosion3(List<GameObject> origins)
{
    foreach (var origin in origins)
    {
        GameObject bullet = Instantiate(triangularPrefab, origin.transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        bullet.transform.rotation = Quaternion.Euler(0, 0, 180f);

        rb.AddForce(Vector2.left * explosionForce, ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-180f, 180f));

        // Destruye el objeto después de 5 segundos
        Destroy(bullet, 5.0f);
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

}