using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevel : MonoBehaviour
{
    public SceneFader fade;

    public void Select(string loadLevel)
    {
        fade.FadeTo(loadLevel);
        
    }
}
