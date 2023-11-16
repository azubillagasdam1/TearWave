using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWhitButton : MonoBehaviour
{
    // Nombre de la escena a la que deseas cambiar
    public void LoadScene(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);  
    }
}
