using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenuScript : MonoBehaviour
{
    public GameObject farmButton;
    public GameObject farmPrefab;
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
        farmButton.GetComponent<Button>().onClick.AddListener(delegate
        {
            GameObject farm = Instantiate(farmPrefab, null);
            CursorScript.instance.ChangeState(new CursorBuildState(), farm.GetComponent<BuildingScript>());
        });
    }
}
