using UnityEngine;
using UnityEngine.UI;

public class CambiarImagen : MonoBehaviour
{
    public Button boton; // Arrastra el botón que deseas usar aquí en el inspector
    public Sprite imagenNivel; // Asigna la imagen de nivel en el inspector
    public Sprite imagenBloqueo; // Asigna la imagen de bloqueo en el inspector
    private Image imagenObjeto;

    private void Start()
    {
        imagenObjeto = GetComponent<Image>(); // Obtén el componente Image del objeto

        // Asegúrate de que se haya asignado el botón y las imágenes en el inspector
        if (boton == null || imagenNivel == null || imagenBloqueo == null)
        {
            Debug.LogError("Asegúrate de asignar el botón y las imágenes en el inspector.");
            return;
        }


        CambiarImagenSegunBoton();
    }

private void CambiarImagenSegunBoton()
{
    ButtonScript buttonScript = boton.GetComponent<ButtonScript>();

    if (buttonScript != null && buttonScript.Desbloqueado)
    {
        Debug.Log("Se cambió la imagen");
        imagenObjeto.sprite = imagenNivel;
    }
    else
    {
        imagenObjeto.sprite = imagenBloqueo;
    }
}
}
