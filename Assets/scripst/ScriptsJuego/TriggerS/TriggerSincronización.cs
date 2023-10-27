using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class sincronización : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public int targetMinute;
    public int targetSecond;
    private bool jugadorDentro = false;
    // Start is called before the first frame update
    void Start()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer no asignado en el inspector.");
            return;
        }

        // Reproduce el video
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(jugadorDentro){
         if (videoPlayer.isPlaying)
        {
            // Verifica si el tiempo actual del video alcanza el minuto y segundo objetivo
            if ((int)videoPlayer.time >= targetMinute * 60 + targetSecond)
            {
                // Hace algo cuando el video alcanza el minuto y segundo objetivo
                // Puedes agregar tus acciones aquí
                Debug.Log("El video ha llegado al minuto " + targetMinute + " y al segundo " + targetSecond);
                
                // Pausa el video (o realiza otras acciones según tus necesidades)
                videoPlayer.Pause();
            }
        }
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
