using UnityEngine.EventSystems;
using UnityEngine;
using System;
using UnityEngine.Events;
public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;
    public Color notEnoughMoneyColor;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
    public GameObject Panel;
    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        definedButton = this.gameObject;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public void OpenPanel()
    {
        if(Panel != null){
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
    
    public void OnMouseDown()
    {
        Input.GetMouseButtonDown(1);
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (turret != null)
        {
            buildManager.SelectNode(this);
            Debug.Log("Cant Build There");
            return;
        }
        if (!buildManager.CanBuild)
            return;
		BuildTurret(buildManager.GetTurretToBuild());
    }
    void BuildTurret (TurretBlueprint blueprint)
	{
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough Money");
            return;
        }
        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(),Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;
        Debug.Log("Turret Built");
	}
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
		{
			Debug.Log("Not enough money to upgrade that!");
			return;
		}

		PlayerStats.Money -= turretBlueprint.upgradeCost;
        Destroy(turret);

		GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
		turret = _turret;

        isUpgraded = true;

		Debug.Log("Turret upgraded!");
    }
    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        Destroy(turret);
        turretBlueprint = null;
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

    void Update () 
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {
                OnClick.Invoke();
            }
        }    
    }
}

