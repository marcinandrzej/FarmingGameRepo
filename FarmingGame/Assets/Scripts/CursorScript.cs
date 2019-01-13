using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public static CursorScript instance;

    public CursorStates cursorState;

    public GameObject choosenObject;

    public void ChangeState(CursorStates newState, BuildingScript building)
    {
        if(cursorState != null)
            cursorState.OnStateExit();
        cursorState = newState;
        cursorState.OnStateEnter(building);
    }

    public GameObject GetChoosenObject()
    {
        return choosenObject;
    }

    public void ChooseObject(GameObject _choosenObject)
    {
        choosenObject = _choosenObject;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
	// Use this for initialization
	void Start ()
    {
        ChangeState(new CursorIdleState(), null);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            cursorState.SecondButtonClick();
        }

        if (Input.GetMouseButtonDown(2))
        {
            cursorState.ThirdButtonClick();
        }
    }
}
