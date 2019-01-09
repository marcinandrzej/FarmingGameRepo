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
    LEATHER = 8
}

public class ResourceManagerScript : MonoBehaviour
{
    public static ResourceManagerScript instance;

    private Dictionary<RESOURCES, int> resources;

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
        resources = new Dictionary<RESOURCES, int>();
        int count = System.Enum.GetNames(typeof(RESOURCES)).Length;
        for (int i = 0; i < count; i++)
        {
            resources[(RESOURCES)i] = 0;
        }
        resources[RESOURCES.WOOD] = 10;
        Invoke("RefreshView", 0.1f);
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

    public void SubtractResources(Dictionary<RESOURCES, int> res)
    {
        if (res == null)
            Debug.Log("Empty");
        int lenght = resources.Count;
        for (int i = 0; i < lenght; i++)
        {
            resources[(RESOURCES)i] -= res[(RESOURCES)i];
        }
    }

    public bool CanBeBuild(Dictionary<RESOURCES, int> cost)
    {
        int lenght = System.Enum.GetValues(typeof(RESOURCES)).Length;
        for (int i = 0; i < lenght; i++)
        {
            if (resources[(RESOURCES)i] < cost[(RESOURCES)i])
                return false;
        }
        return true;
    }

    public void RefreshView()
    {
        ResourceMenuScript.instance.UpdateResources(resources);
    }
}
