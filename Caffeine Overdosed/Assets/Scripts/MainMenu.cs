using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad = "";
    public SceneFader fade;

    public void Play ()
    {
        fade.FadeTo(sceneToLoad);
    }

    public void Quit ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
