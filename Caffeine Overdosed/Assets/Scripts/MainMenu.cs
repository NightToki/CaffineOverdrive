using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad = "Level1";
    public void Play ()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Quit ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
