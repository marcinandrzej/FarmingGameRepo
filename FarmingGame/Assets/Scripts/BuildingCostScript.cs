using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCostScript : MonoBehaviour
{
    public int COINS_COST;
    public int COINS_INCOME;
    public int GRAIN;
    public int MEAT;
    public int COTTON;
    public int IRON_ORE;
    public int COAL;
    public int WOOD;
    public int STEEL;
    public int LINEN ;
    public int LEATHER;
    public int SALT;


    private int level;
    private int refundCost;
    private int incomeRise;
    private Dictionary<RESOURCES, int> buildingCost;
    private Dictionary<RESOURCES, int> upgradeCost;

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

    public Dictionary<RESOURCES, int> UpgradeCost
    {
        get
        {
            return upgradeCost;
        }

        set
        {
            upgradeCost = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            level = value;
        }
    }

    public int RefundCost
    {
        get
        {
            return refundCost;
        }

        set
        {
            refundCost = value;
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
        Level = 1;
        RefundCost = -COINS_COST;
        incomeRise = COINS_INCOME;
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
        BuildingCost[RESOURCES.SALT] = SALT;

        UpgradeCost = new Dictionary<RESOURCES, int>();
        for (int i = 0; i < BuildingCost.Count; i++)
        {
            if (BuildingCost[(RESOURCES)i] > 0)
            {
                UpgradeCost[(RESOURCES)i] = 1;
            }
            else
            {
                UpgradeCost[(RESOURCES)i] = 0;
            }
        }
    }

    public void LevelUp()
    {
        COINS_COST *= 2;
        ResourceManagerScript.instance.Coins += COINS_COST;
        ResourceManagerScript.instance.Income += COINS_INCOME;
        COINS_INCOME += incomeRise;
        for (int i = 0; i < BuildingCost.Count; i++)
        {
            BuildingCost[(RESOURCES)i] += UpgradeCost[(RESOURCES)i];
            if (UpgradeCost[(RESOURCES)i] != 0)
            {
                ResourceManagerScript.instance.AddResource((RESOURCES)i, UpgradeCost[(RESOURCES)i]);
            }
        }
        UpdateUpgradeCost(Level);
        Level++;
        ResourceManagerScript.instance.RefreshView();
        ResourceManagerScript.instance.RefreshCoins();
    }

    public void DestroyBuilding()
    {
        ResourceManagerScript.instance.Income -= COINS_INCOME;
        for (int i = 0; i < BuildingCost.Count; i++)
        {
            if (BuildingCost[(RESOURCES)i] != 0)
            {
                ResourceManagerScript.instance.SubResource((RESOURCES)i, BuildingCost[(RESOURCES)i]);
            }
        }
        ResourceManagerScript.instance.AddCoins(RefundCost);
        ResourceManagerScript.instance.RefreshView();
        ResourceManagerScript.instance.RefreshCoins();
    }

    public void UpdateUpgradeCost(int lvl)
    {
        //UpgradeCost = new Dictionary<RESOURCES, int>();
        for (int i = 0; i < BuildingCost.Count; i++)
        {
            if (BuildingCost[(RESOURCES)i] > 0)
            {
                UpgradeCost[(RESOURCES)i] = 1;
            }
            else if(BuildingCost[(RESOURCES)i] < 0)
            {
                UpgradeCost[(RESOURCES)i] = -lvl%2;
            }
            else
            {
                UpgradeCost[(RESOURCES)i] = 0;
            }
        }
    }
}
