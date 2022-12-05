using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    // Update is called once per frame
    void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver)
            return;
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        SceneManager.LoadScene("GameOver");
    }

    public void WinLevel()
    {
        GameIsOver = true;
        SceneManager.LoadScene("WinScreen");
    }
}
