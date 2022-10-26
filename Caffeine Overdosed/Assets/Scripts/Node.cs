using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    public Color notEnoughMoneyColor;
     
    [Header("Optional")]

    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;


    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }


    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if (turret != null)
        {
            Debug.Log("Cant Build There");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
      
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;

        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        rend.material.color = hoverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    
}

