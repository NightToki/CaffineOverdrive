using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node target; 
    public GameObject ui;
    public void SetTarget(Node Passedtarget){
        this.target = Passedtarget;

        transform.position = target.GetBuildPosition();
        ui.SetActive(true);
    }
    public void hideUI()
    {
        ui.SetActive(false);
    }
}
