using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenuScript : MonoBehaviour
{
    public GameObject buildPanel;
    public GameObject[] buildingsPrefabs;
    public Sprite[] buildingsSprites;

    private GameObject[] buildButtons;
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
        buildButtons = GuiScript.instance.FillWithButtons(buildPanel, 3, buildingsSprites);

        for (int i = 0; i < buildButtons.Length; i++)
        {
            int x = i;
            if (x < buildingsPrefabs.Length)
            {
                buildButtons[x].GetComponent<Button>().onClick.AddListener(delegate
                {
                GameObject building = Instantiate(buildingsPrefabs[x], null);
                CursorScript.instance.ChangeState(new CursorBuildState(), building.GetComponent<BuildingScript>());
                });
            }
        }
    }
}
