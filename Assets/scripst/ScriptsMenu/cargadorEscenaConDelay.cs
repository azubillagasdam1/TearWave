using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoadScene : MonoBehaviour
{
    public string sceneToLoad;  // Nombre de la escena a cargar
    public float loadDelayInSeconds = 5f;  // Tiempo de espera en segundos

    private void Start()
    {
        // Inicia la corrutina que maneja la carga automática
        StartCoroutine(LoadSceneAfterDelay());
    }

    private System.Collections.IEnumerator LoadSceneAfterDelay()
    {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(loadDelayInSeconds);

        // Cambia a la escena especificada
        SceneManager.LoadScene(sceneToLoad);
    }
}
