using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenuScript : MonoBehaviour
{
    public static BuildingMenuScript instance;

    public GameObject buildPanel;
    public GameObject[] buildingsPrefabs;
    public Sprite[] buildingsSprites;

    private GameObject[] buildButtons;

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

    private void SetUp()
    {
        buildButtons = GuiScript.instance.FillWithButtons(buildPanel, 5, buildingsSprites);

        for (int i = 0; i < buildButtons.Length; i++)
        {
            int x = i;
            if (x < buildingsPrefabs.Length)
            {
                buildButtons[x].GetComponent<Button>().onClick.AddListener(delegate
                {
                    GameObject building = Instantiate(buildingsPrefabs[x], new Vector3(0,1000,0),Quaternion.identity);
                    CursorScript.instance.ChangeState(new CursorBuildState(), building.GetComponent<BuildingScript>());
                    SelectPanelScript.instance.SelectionShow(building.GetComponent<BuildingScript>(), buildingsSprites[x]);
                });
            }
        }
    }
}
