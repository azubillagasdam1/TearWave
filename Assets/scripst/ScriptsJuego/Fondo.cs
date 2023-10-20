using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Fondo : MonoBehaviour
{
    private MovimientoPersonaje jugador;
    private VideoPlayer videoPlayer; // Referencia al VideoPlayer

    void Start()
    {
        jugador = GameObject.Find("Jugador").GetComponent<MovimientoPersonaje>();
        videoPlayer = GetComponent<VideoPlayer>(); // Obtén la referencia al VideoPlayer en este GameObject
    }

    void Update()
    {
        if (!jugador.getVivo())
        {
            // Si el jugador ha muerto, detén el video
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
            }
        }
    }
}
