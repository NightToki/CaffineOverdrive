
using UnityEngine;

public class Shop : MonoBehaviour
    
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint gunTurret;
    public TurretBlueprint gunBarrage;
    public TurretBlueprint MissleTurret;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()
	{
		buildManager.SelectTurretToBuild(missileLauncher);
	}
    public void SelectGunTurret()
	{
		buildManager.SelectTurretToBuild(gunTurret);
	}
    public void SelectGunBarrage()
	{
		buildManager.SelectTurretToBuild(gunBarrage);
	}
    public void SelectMissleTurret()
	{
		buildManager.SelectTurretToBuild(MissleTurret);
	} 
}
