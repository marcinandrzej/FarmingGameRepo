using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public int sizeX;
    public int sizeZ;
    public string buildingName;
    public string description;

    public GameObject buildingView;
    private Renderer rend;
    private Color32 color;
    private Color32 highlightColor;
    private Sprite img;

    public Sprite Img
    {
        get
        {
            return img;
        }

        set
        {
            img = value;
        }
    }

    // Use this for initialization
    void Start ()
    {
        rend = buildingView.GetComponentInChildren<Renderer>();
        color = rend.material.color;
        highlightColor = new Color32((byte)(color.r * 0.5f), (byte)(color.g * 0.5f), (byte)(color.b * 0.5f), color.a);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void HighlightOnOff(bool on)
    {
        if (on)
        {
            rend.material.color = highlightColor;
        }
        else
        {
            rend.material.color = color;
        }
    }

    public void Build(Vector3 position)
    {
        gameObject.transform.position = position;
        rend.material.color = color;
    }

    public void Move(Vector3 position)
    {
        gameObject.transform.position = position;
    }

    public void Rotate()
    {
        int temp = sizeX;
        sizeX = sizeZ;
        sizeZ = temp;

        Vector3 localPos = buildingView.transform.localPosition;
        buildingView.transform.Rotate(Vector3.up, 90);
        buildingView.transform.localPosition = new Vector3(localPos.z, localPos.y, localPos.x);
    }

    public void DestroyBuilding()
    {
        Destroy(gameObject);
    }
}
