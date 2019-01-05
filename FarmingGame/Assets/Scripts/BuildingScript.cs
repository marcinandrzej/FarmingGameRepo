using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public int sizeX;
    public int sizeZ;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Build(Vector3 position)
    {
        gameObject.transform.position = position;
    }

    public void Move(Vector3 position)
    {
        gameObject.transform.position = position;
    }
}
