using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Sincronizacion : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public int targetMinute;
    public int targetSecond;
    private bool jugadorDentro = false;
    private bool videoReproducido = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    
        if (jugadorDentro && !videoReproducido)
        {
            Debug.Log("Seteando Tiempo");
            videoPlayer.time = (targetMinute * 60 + targetSecond);
            videoPlayer.Play();
            audioSource.Play();
            videoReproducido = true; // Marcar el video como reproducido para evitar la reproducción repetida
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         
        if (collision.CompareTag("Jugador"))
        {
            Debug.Log("EntroEnSincronizador");
            jugadorDentro = true;
        }
    }
  
}
