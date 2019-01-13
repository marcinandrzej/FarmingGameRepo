using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanelScript : MonoBehaviour
{
    public static SelectPanelScript instance;

    public GameObject selectionPanel;
    public Image selectionImage;
    public Text selectionTxt;
    public Button upgradeButton;
    public Button destroyButton;

    private const int MAX_LVL = 5;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Use this for initialization
    void Start ()
    {
        SetUp();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetUp()
    {
        upgradeButton.onClick.AddListener(delegate
        {
            if (CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().Level < MAX_LVL)
            {
                if (ResourceManagerScript.instance.CanBeBuild(
                CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().UpgradeCost,
                CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().COINS_COST * 2))
                {
                    CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().LevelUp();
                    ResourceMenuScript.instance.UpdateCost(
                        CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().UpgradeCost,
                    CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().COINS_COST * 2,
                    false);
                    SelectionShow(CursorScript.instance.GetChoosenObject().GetComponent<BuildingScript>(),
                        CursorScript.instance.GetChoosenObject().GetComponent<BuildingScript>().Img);
                }
                if (CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().Level >= MAX_LVL)
                {
                    HideCost();
                }
            }
        });

        destroyButton.onClick.AddListener(delegate
        {
            if (ResourceManagerScript.instance.CanBeRemoved(
            CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().BuildingCost))
            {
                CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().DestroyBuilding();
                CursorScript.instance.GetChoosenObject().GetComponent<BuildingScript>().DestroyBuilding();
                CursorScript.instance.ChangeState(new CursorIdleState(), null);
                HideCost();
            }
        });
    }

    public void SelectionShow(BuildingScript building, Sprite img)
    {
        selectionImage.sprite = img;
        selectionTxt.text = building.buildingName + "\nLevel: " + building.GetComponent<BuildingCostScript>().Level.ToString()
            + "\nTax income: " + building.GetComponent<BuildingCostScript>().COINS_INCOME.ToString() + "\n" + building.description;
    }

    public void TurnButtonsOnOff(bool on)
    {
        destroyButton.gameObject.SetActive(on);
        upgradeButton.gameObject.SetActive(on);
    }

    public void ShowCost()
    {
        if (CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().Level < MAX_LVL)
        {
            ResourceMenuScript.instance.UpdateCost(
                    CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().UpgradeCost,
                    CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().COINS_COST * 2,
                    false);
        }
    }

    public void ShowDestroyCost()
    {
        ResourceMenuScript.instance.UpdateCost(
                CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().BuildingCost,
                CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().RefundCost,
                true);
    }

    public void HideCost()
    {
        ResourceMenuScript.instance.HideCost();
    }
}
