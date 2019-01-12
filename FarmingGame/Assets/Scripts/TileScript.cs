using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private int x;
    private int z;
    public GameObject onTile;

    private Renderer rend;
    private Color32 color;
    private Color32 highlightColor;

    public int X
    {
        get
        {
            return x;
        }

        set
        {
            x = value;
        }
    }

    public int Z
    {
        get
        {
            return z;
        }

        set
        {
            z = value;
        }
    }

    public void SetIndexes(int _x, int _z)
    {
        X = _x;
        Z = _z;
    }

    public void PlaceObject(GameObject _onTile)
    {
        onTile = _onTile;
    }

    public GameObject GetObject()
    {
        return onTile;
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

    void OnMouseEnter()
    {
        CursorScript.instance.cursorState.TileEnter(this);
    }

    void OnMouseExit()
    {
        CursorScript.instance.cursorState.TileExit(this);
    }

    void OnMouseDown()
    {
        CursorScript.instance.cursorState.TileClick(this);
    }

    // Use this for initialization
    void Start ()
    {
        onTile = null;
        rend = gameObject.GetComponentInChildren<Renderer>();
        color = rend.material.color;
        highlightColor = new Color32((byte)(color.r * 0.5f), (byte)(color.g * 0.5f), (byte)(color.b * 0.5f), color.a);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
