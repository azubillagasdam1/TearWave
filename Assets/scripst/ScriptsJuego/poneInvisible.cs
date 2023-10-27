using UnityEngine;

public class ponerInvisible : MonoBehaviour

{
public bool invisible = false;
    private void Start(){
        if(invisible){
        SetChildrenAlphaToZero();
        }
    }
    // Método para establecer la transparencia (alfa) de los elementos hijos a 0.
    public void SetChildrenAlphaToZero()
    {
        // Recorre todos los elementos hijos del GameObject actual.
        foreach (Transform child in transform)
        {
            // Verifica si el elemento hijo tiene un SpriteRenderer.
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                // Obten el color actual del SpriteRenderer.
                Color currentColor = spriteRenderer.color;
                
                // Establece el valor alfa a 0 (totalmente transparente).
                currentColor.a = 0f;

                // Asigna el nuevo color al SpriteRenderer.
                spriteRenderer.color = currentColor;
            }
        }
    }

    // Puedes llamar a este método desde otros scripts o desde el Inspector.
}
