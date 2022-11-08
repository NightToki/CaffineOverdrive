using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    public SceneFader fade;
    
    public Button[] levels;

    void Start()
    {
        int levelBeat = PlayerPrefs.GetInt("levelBeat",0); 

        for(int ctr = 0; ctr < levels.Length; ctr++)
        {
            if(ctr > levelBeat )
                levels[ctr].interactable = false;
        } 
    }

    public void Select(string loadLevel)
    {
        fade.FadeTo(loadLevel);
        
    }
}
