using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonFunctions : MonoBehaviour
{
    public Object sceneToLoad;
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        if(sceneToLoad != null)
            SceneManager.LoadSceneAsync(sceneToLoad.name);
    }

    public void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
