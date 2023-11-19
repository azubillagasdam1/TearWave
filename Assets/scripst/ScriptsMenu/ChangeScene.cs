using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    public string sceneToLoad;  // Nombre de la escena a cargar
    public string nivelACargar;  // Parámetro que se enviará a la siguiente escena

    private void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        // Pasa el parámetro a la siguiente escena antes de cargarla
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        PlayerPrefs.SetString("NivelACargar", nivelACargar);
    }
}
