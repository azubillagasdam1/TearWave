using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    public string sceneToLoad;  // Nombre de la escena a cargar

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
        // Cambia a la escena especificada al hacer clic
        SceneManager.LoadScene(sceneToLoad);
    }
}
