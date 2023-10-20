using UnityEngine;
using UnityEngine.UI;

public class FlickerEffect : MonoBehaviour
{
    public Image imageToModify;
    public float minOpacity = 0.1f; // Opacidad mínima (luz apagada)
    public float maxOpacity = 1.0f; // Opacidad máxima (luz encendida)
    public float flickerInterval = 0.2f; // Intervalo entre parpadeos
    public float probabilidadParaApagar = 0.01f; // Probabilidad de apagar la luz en cada parpadeo
    public float tiempoDeApagado = 2.0f; // Duración del apagado

    private AudioSource audioSource;
    private float audioVolume = 0.5f; // Volumen del audio
    private float timeSinceLastFlicker = 0f;
    private bool isFlickering = false;
    private bool isApagado = false;
    private float apagadoTimer = 0f;

    private void Start()
    {
          audioSource = GetComponent<AudioSource>();
        if (imageToModify == null)
        {
            imageToModify = GetComponent<Image>();
        }
    }

    private void Update()
    {
        if (isApagado)
        {
         
            SetOpacity(0f);
            // Mantener la luz apagada durante el tiempo especificado con opacidad 0f
            apagadoTimer += Time.deltaTime;
            if (apagadoTimer >= tiempoDeApagado)
            {
                isApagado = false;
                apagadoTimer = 0f;
                // Restablecer la opacidad a 0.1f al salir del apagado
                SetOpacity(minOpacity);
                PlaySound();
            }
         
        }

        else if (!isFlickering)
        {
            // Si no está parpadeando, espera un intervalo antes de empezar
            timeSinceLastFlicker += Time.deltaTime;
            if (timeSinceLastFlicker >= flickerInterval)
            {
                isFlickering = true;
                timeSinceLastFlicker = 0f;
                // Cambiar la opacidad de manera aleatoria entre minOpacity y maxOpacity
                float newAlpha = Random.Range(minOpacity, maxOpacity);
                SetOpacity(newAlpha);

                // Verificar si se debe apagar la luz basado en la probabilidad
                if (Random.value <= probabilidadParaApagar)
                {
                    isApagado = true;
                }
            }
        }
        else
        {
            // Si ha pasado el intervalo de parpadeo, detén el parpadeo
            timeSinceLastFlicker += Time.deltaTime;
            if (timeSinceLastFlicker >= flickerInterval)
            {
                isFlickering = false;
                timeSinceLastFlicker = 0f;
            }
        }
    }

  private void SetOpacity(float alpha)
    {
        Color currentColor = imageToModify.color;
        currentColor.a = alpha;
        imageToModify.color = currentColor;
    }

     private void PlaySound(){
     audioSource.volume = audioVolume;

        // Reproduce el sonido
        audioSource.Play();
        Debug.LogWarning("Interruptor On");
    }
}

   