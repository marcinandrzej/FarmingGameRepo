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
            if (ResourceManagerScript.instance.CanBeBuild(
                CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().UpgradeCost,
                CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().COINS_COST * 2))
            {
                CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().LevelUp();
                ResourceMenuScript.instance.UpdateCost(
                    CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().UpgradeCost,
                CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().COINS_COST * 2);
            }
        });
    }

    public void SelectionShow(BuildingScript building, Sprite img)
    {
        selectionImage.sprite = img;
        selectionTxt.text = building.buildingName + "\n" + building.description;
    }

    public void TurnButtonsOnOff(bool on)
    {
        destroyButton.gameObject.SetActive(on);
        upgradeButton.gameObject.SetActive(on);
    }

    public void ShowCost()
    {
        ResourceMenuScript.instance.UpdateCost(
                CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().UpgradeCost,
                CursorScript.instance.GetChoosenObject().GetComponent<BuildingCostScript>().COINS_COST * 2);
    }

    public void HideCost()
    {
        ResourceMenuScript.instance.HideCost();
    }
}
