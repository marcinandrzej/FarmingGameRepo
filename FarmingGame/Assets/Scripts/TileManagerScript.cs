using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagerScript : MonoBehaviour
{
    public static TileManagerScript instance;

    public GameObject tilePrefab;

    private TileScript[,] tiles;

    public void SetUp(int sizeX, int sizeZ)
    {
        tiles = new TileScript[sizeX, sizeZ];

        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                tiles[x, z] = Instantiate(tilePrefab, transform).GetComponent<TileScript>();
                tiles[x, z].SetIndexes(x, z);
                tiles[x, z].transform.position = new Vector3(x, 0, z);
            }
        }
    }

    public bool CanBeBuild(int _x, int _z, int sizeX, int sizeZ)
    {
        for (int x = _x; x < _x + sizeX; x++)
        {
            for (int z = _z; z < _z + sizeZ; z++)
            {
                if (!IsInGrid(x, z) || tiles[x, z].GetObject() != null)
                    return false;
            }
        }
        return true;
    }

    public bool OcuppyTiles(GameObject building, int _x, int _z, int sizeX, int sizeZ)
    {
        for (int x = _x; x < _x + sizeX; x++)
        {
            for (int z = _z; z < _z + sizeZ; z++)
            {
                tiles[x, z].PlaceObject(building);
            }
        }
        return true;
    }

    private bool IsInGrid(int _x, int _z)
    {
        if (_x < 0 || _x >= tiles.GetLength(0) || _z < 0 || _z >= tiles.GetLength(1))
            return false;
        return true;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
	// Use this for initialization
	void Start ()
    {
        SetUp(20,20);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
