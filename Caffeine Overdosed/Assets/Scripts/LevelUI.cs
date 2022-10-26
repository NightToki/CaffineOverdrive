using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    public TextMeshProUGUI levelText;


    // Update is called once per frame
    void Update()
    {
        levelText.text = PlayerStats.Level.ToString() + " Level";

    }
}
