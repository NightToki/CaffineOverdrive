
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

    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }



   public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
        Debug.Log("Not enough Money");
        return;
        }
        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(),Quaternion.identity);
        node.turret = turret;
        Debug.Log("Turret Built: Money Left: " + PlayerStats.Money);
    }
    public void SelectNode(Node node){

        if(selectedNode == node){
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode(){
        selectedNode = null;
        nodeUI.hideUI();
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

}
