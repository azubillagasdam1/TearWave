using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public bool desbloqueado = true;

    private Button button; // Agregamos una referencia al componente Button
    private Image buttonImage;
    private AudioSource audioSource;
    private bool isClicking = false;
    private Color normalColor = new Color(1f, 1f, 1f, 0f); // Blanco con opacidad al 0%
    private Color hoverColor = new Color(1f, 1f, 1f, 0.3f); // Blanco con opacidad al 30%
    private Color clickColor = new Color(1f, 1f, 1f, 1f); // Blanco con opacidad al 100%
    private Vector3 originalScale;
    private Vector3 targetScale;
    private float scaleSpeed = 5f; // Velocidad de la transición de escala

    private void Start()
    {
        button = GetComponent<Button>(); // Obtén el componente Button
        buttonImage = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>(); // Asegúrate de que tengas un componente AudioSource adjunto al mismo GameObject que este script
        buttonImage.color = normalColor;

        originalScale = transform.localScale;
        targetScale = originalScale;

        // Llama al método para actualizar el estado interactable en función de desbloqueado
        UpdateInteractableState();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isClicking)
        {
            buttonImage.color = hoverColor;
            targetScale = originalScale * 1.1f; // Escala un 10% más grande en el hover
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isClicking)
        {
            buttonImage.color = normalColor;
            targetScale = originalScale;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClicking = true;
        buttonImage.color = clickColor;
        Debug.LogWarning("Click...");

        // Reproduce el audio cuando se mantiene presionado el botón
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isClicking = false;
        buttonImage.color = hoverColor; // Cambia de nuevo a opacidad del 20% cuando se suelta el botón
        targetScale = originalScale * 1.1f; // Escala un 10% más grande en el hover
    }

    private void Update()
    {
        // Interpola suavemente la escala del botón hacia el valor objetivo
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }

    // Método para actualizar la propiedad interactable en función de desbloqueado
    private void UpdateInteractableState()
    {
        if (button != null)
        {
            button.interactable = desbloqueado;
        }
    }

    public bool Desbloqueado
    {
        get { return desbloqueado; }
        set
        {
            desbloqueado = value;
            UpdateInteractableState(); // Llama al método cuando cambie desbloqueado
        }
    }
}
