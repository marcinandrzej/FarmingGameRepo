using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript instance;

    public GameObject selectionPanel;
    public GameObject buildingPanel;
    public GameObject resouurcePanel;

    void Awake()
    {
        if(instance == null)
            instance = this;
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
