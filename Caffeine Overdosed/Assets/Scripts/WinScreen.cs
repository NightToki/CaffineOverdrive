using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SelectLevel.levelBeat += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LevelSelector()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
