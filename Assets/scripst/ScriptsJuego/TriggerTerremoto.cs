using UnityEngine;
using System.Collections;

public class TriggerTerremoto : MonoBehaviour
{
    public float duration = 0.5f;
    public float magnitude = 0.1f;
    public float fadeInDuration = 0.2f;  // Duración del efecto "fadeIn".
    public float fadeOutDuration = 0.2f; // Duración del efecto "fadeOut".

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisión con el objeto 'Jugador' detectada");
        if (collision.CompareTag("Jugador"))
        {
            StartCoroutine(ShakeCamera());
        }
    }

    private IEnumerator ShakeCamera()
    {
        Vector3 originalPos = mainCamera.transform.localPosition;
        float elapsedTime = 0f;
        float fadeInFactor = 0f;
        float fadeOutFactor = 1f;

        while (elapsedTime < duration)
        {
            float xOffset = Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = Random.Range(-0.5f, 0.5f) * magnitude;

            if (elapsedTime < fadeInDuration)
            {
                fadeInFactor = elapsedTime / fadeInDuration;
            }
            else if (elapsedTime > duration - fadeOutDuration)
            {
                fadeOutFactor = 1 - ((elapsedTime - (duration - fadeOutDuration)) / fadeOutDuration);
            }

            mainCamera.transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z) * (fadeInFactor * fadeOutFactor);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.localPosition = originalPos;
    }
}
