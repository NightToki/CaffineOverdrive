using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 2;

    public static int Level;
    public int startLevel = 1;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Level = startLevel;
    }


}
