using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
 

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("GameOver");
    }
}
