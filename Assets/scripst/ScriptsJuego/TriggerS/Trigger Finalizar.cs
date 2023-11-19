using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerFinalizar : MonoBehaviour
{
    private MovimientoPersonaje jugador;
    public GameObject canvas;
    public bool finalizado;

    void Start()
    {
        canvas.SetActive(false);
        jugador = GameObject.Find("Jugador").GetComponent<MovimientoPersonaje>();
        finalizado = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jugador"))
        {
            canvas.SetActive(true);
            finalizado = true;
        }
    }

    void Update()
    {
        if (finalizado)
        {
            if (Input.GetKeyDown(KeyCode.Return)) // Cambiado de KeyCode.enter a KeyCode.Return
            {
                // Cargar la escena específica al presionar "Enter"
                SceneManager.LoadScene("MenuInicio");
            }
        }
    }
}
