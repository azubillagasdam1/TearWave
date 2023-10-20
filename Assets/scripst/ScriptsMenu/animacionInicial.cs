using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class VideoControl : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button nextSceneButton;
    public CanvasGroup buttonCanvasGroup;
    public float fadeDuration;
    public float buttonAppearDelay; // Tiempo en segundos para que aparezca el botón

    private void Start()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("El componente VideoPlayer no está asignado.");
            return;
        }

        videoPlayer.loopPointReached += OnVideoEnd;

        nextSceneButton.interactable = false;
        buttonCanvasGroup.alpha = 0f;

        Invoke("StartButtonAppear", buttonAppearDelay);
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        ChangeToNextScene();
    }

    public void ChangeToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void StartButtonAppear()
    {
        StartCoroutine(FadeInButton(fadeDuration));
    }

    private IEnumerator FadeInButton(float duration)
    {
        float elapsedTime = 0f;
        float startAlpha = 0f;
        float targetAlpha = 1f;

        while (elapsedTime < duration)
        {
            buttonCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        buttonCanvasGroup.alpha = targetAlpha;
        nextSceneButton.interactable = true;
        nextSceneButton.onClick.AddListener(ChangeToNextScene);
    }
}
