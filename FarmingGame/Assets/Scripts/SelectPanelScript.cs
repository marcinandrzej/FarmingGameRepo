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

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SelectionShow(BuildingScript building, Sprite img)
    {
        selectionImage.sprite = img;
        selectionTxt.text = building.buildingName + "\nIn:" + building.income + "\nOut:" + building.outcome + "\n" + building.description;
    }
}
