using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MinionUI : MonoBehaviour
{
    public TextMeshProUGUI minionText;

    // Update is called once per frame
    void Update()
    {
        minionText.text = "Minions Killed: " + PlayerStats.Count.ToString();
    }
}
