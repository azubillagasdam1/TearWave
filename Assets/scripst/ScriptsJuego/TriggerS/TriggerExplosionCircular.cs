using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject triangularPrefab;
    public int numberOfObjects = 10;
    public float explosionForce = 10f;
    public GameObject explosionOrigin; // Objeto que lanza la explosión

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
            CreateExplosion();
            explosionEjecutada = true; // Marcar que la explosión se ha ejecutado
        }
    }

    void CreateExplosion()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * (360f / numberOfObjects);
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.up;

            GameObject triangular = Instantiate(triangularPrefab, explosionOrigin.transform.position, Quaternion.identity);
            Rigidbody2D rb = triangular.GetComponent<Rigidbody2D>();

            rb.AddForce(direction * explosionForce, ForceMode2D.Impulse);
            rb.AddTorque(Random.Range(-180f, 180f));
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
