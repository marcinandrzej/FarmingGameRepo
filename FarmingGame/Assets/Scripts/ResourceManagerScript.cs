using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RESOURCES
{
    GRAIN = 0,
    MEAT = 1,
    COTTON = 2,
    IRON_ORE = 3,
    COAL = 4,
    WOOD = 5,
    STEEL = 6,
    LINEN = 7,
    LEATHER = 8,
    SALT = 9
}

public class ResourceManagerScript : MonoBehaviour
{
    public static ResourceManagerScript instance;

    private Dictionary<RESOURCES, int> resources;

    private int coinsLimit;
    private int coins;
    private int income;

    public int Coins
    {
        get
        {
            return coins;
        }

        set
        {
            coins = value;
        }
    }

    public int Income
    {
        get
        {
            return income;
        }

        set
        {
            income = value;
        }
    }

    public int CoinsLimit
    {
        get
        {
            return coinsLimit;
        }

        set
        {
            coinsLimit = value;
        }
    }

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
        CoinsLimit = 5000;
        Coins = 500;
        Income = 0;
        resources = new Dictionary<RESOURCES, int>();
        int count = System.Enum.GetNames(typeof(RESOURCES)).Length;
        for (int i = 0; i < count; i++)
        {
            resources[(RESOURCES)i] = 0;
        }
        Invoke("RefreshCoins", 0.1f);
        InvokeRepeating("CollectTaxes", 1, 10);
    }

    public void AddResource(RESOURCES res, int quantity)
    {
        resources[res] += quantity;
    }

    public void SubResource(RESOURCES res, int quantity)
    {
        resources[res] -= quantity;
    }

    public Dictionary<RESOURCES, int> GetResources()
    {
        return resources;
    }

    public void AddResources(Dictionary<RESOURCES, int> res)
    {
        int lenght = resources.Count;
        for (int i = 0; i < lenght; i++)
        {
            resources[(RESOURCES)i] += res[(RESOURCES)i];
        }
    }

    public void SubtractResources(Dictionary<RESOURCES, int> res)
    {
        int lenght = resources.Count;
        for (int i = 0; i < lenght; i++)
        {
            resources[(RESOURCES)i] -= res[(RESOURCES)i];
        }
    }

    public bool CanBeBuild(Dictionary<RESOURCES, int> cost, int coinsCost)
    {
        if (Coins + coinsCost < 0)
            return false;
        int lenght = System.Enum.GetValues(typeof(RESOURCES)).Length;
        for (int i = 0; i < lenght; i++)
        {
            if (resources[(RESOURCES)i] + cost[(RESOURCES)i] < 0)
                return false;
        }
        return true;
    }

    public bool CanBeRemoved(Dictionary<RESOURCES, int> cost)
    {
        int lenght = System.Enum.GetValues(typeof(RESOURCES)).Length;
        for (int i = 0; i < lenght; i++)
        {
            if (resources[(RESOURCES)i] - cost[(RESOURCES)i] < 0)
                return false;
        }
        return true;
    }

    private void CollectTaxes()
    {
        if (Income != 0 && Coins < CoinsLimit)
        {
            Coins = Mathf.Min(CoinsLimit, (Coins + Income));
            RefreshCoins();
        }
    }

    public void AddCoins(int _coins)
    {
        Coins = Mathf.Min(Coins + _coins, CoinsLimit);
    }

    public void RefreshView()
    {
        ResourceMenuScript.instance.UpdateResources(resources);
        ResourceMenuScript.instance.UpdateCoins(Coins);
    }

    public void RefreshCoins()
    {
        ResourceMenuScript.instance.UpdateCoins(Coins);
    }
}
