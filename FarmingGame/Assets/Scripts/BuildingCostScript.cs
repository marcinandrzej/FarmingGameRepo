using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCostScript : MonoBehaviour
{
    public int GRAIN;
    public int MEAT;
    public int COTTON;
    public int IRON_ORE;
    public int COAL;
    public int WOOD;
    public int STEEL;
    public int LINEN ;
    public int LEATHER;

    private Dictionary<RESOURCES, int> buildingCost;

    public Dictionary<RESOURCES, int> BuildingCost
    {
        get
        {
            return buildingCost;
        }

        set
        {
            buildingCost = value;
        }
    }

    void Awake()
    {
        SetUp();
    }
    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetUp()
    {
        BuildingCost = new Dictionary<RESOURCES, int>();
        BuildingCost[RESOURCES.COAL] = COAL;
        BuildingCost[RESOURCES.COTTON] = COTTON;
        BuildingCost[RESOURCES.GRAIN] = GRAIN;
        BuildingCost[RESOURCES.IRON_ORE] = IRON_ORE;
        BuildingCost[RESOURCES.LEATHER] = LEATHER;
        BuildingCost[RESOURCES.LINEN] = LINEN;
        BuildingCost[RESOURCES.MEAT] = MEAT;
        BuildingCost[RESOURCES.STEEL] = STEEL;
        BuildingCost[RESOURCES.WOOD] = WOOD;
    }
}
