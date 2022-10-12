using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Buildmanager in scene!");
            return;
        }
        instance = this;
    }
    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;
    private GameObject turretToBuild;

 
    

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
 
    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

}
