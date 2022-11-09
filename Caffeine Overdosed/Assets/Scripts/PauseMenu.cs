using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
//using UnityEngine.InputSystem;
using System.Runtime.InteropServices.ComTypes;

public class PauseMenu : MonoBehaviour
{
   // PlayerControls playerControls;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Awake()
    {
        //playerControls = new PlayerControls();
     
        //playerControls.GamePlay.Buttons.performed += ctx => Pause();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    //void onEnable()
    //{
      //  playerControls.Gameplay.Buttons.Enable();
    //}
    //void onDisable()
    //{
       // playerControls.Gameplay.Buttons.Disable();
    //}
}