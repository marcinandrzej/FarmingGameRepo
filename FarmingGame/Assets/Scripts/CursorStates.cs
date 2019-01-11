using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public interface CursorStates
{
    void OnStateEnter(BuildingScript _building);
    void OnStateExit();
    void TileEnter(TileScript tile);
    void TileExit(TileScript tile);
    void TileClick(TileScript tile);
    void SecondButtonClick();
}

public class CursorIdleState : CursorStates
{
    public void OnStateEnter(BuildingScript _building)
    {
        CursorScript.instance.ChooseObject(null);
    }

    public void OnStateExit()
    {

    }

    public void TileClick(TileScript tile)
    {
        CursorScript.instance.ChooseObject(tile.GetObject());
    }

    public void TileEnter(TileScript tile)
    {
        tile.HighlightOnOff(true);
    }

    public void TileExit(TileScript tile)
    {
        tile.HighlightOnOff(false);
    }

    public void SecondButtonClick()
    {
        CursorScript.instance.ChooseObject(null);
    }
}

public class CursorBuildState : CursorStates
{
    private BuildingScript building;

    public void OnStateEnter(BuildingScript _building)
    {
        building = _building;
        ResourceMenuScript.instance.UpdateCost(building.gameObject.GetComponent<BuildingCostScript>().BuildingCost,
            building.gameObject.GetComponent<BuildingCostScript>().COINS_COST);
    }

    public void OnStateExit()
    {
        if (building != null)
        {
            building.DestroyBuilding();
            building = null;
        }
        ResourceMenuScript.instance.HideCost();
    }

    public void TileClick(TileScript tile)
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (building != null && TileManagerScript.instance.CanBeBuild(tile.X, tile.Z, building.sizeX, building.sizeZ) &&
            ResourceManagerScript.instance.CanBeBuild(building.gameObject.GetComponent<BuildingCostScript>().BuildingCost,
            building.gameObject.GetComponent<BuildingCostScript>().COINS_COST))
            {
                ResourceManagerScript.instance.AddResources(building.gameObject.GetComponent<BuildingCostScript>().BuildingCost);
                ResourceManagerScript.instance.Coins += building.gameObject.GetComponent<BuildingCostScript>().COINS_COST;
                ResourceManagerScript.instance.Income += building.gameObject.GetComponent<BuildingCostScript>().COINS_INCOME;
                ResourceManagerScript.instance.RefreshView();
                TileManagerScript.instance.OcuppyTiles(building.gameObject, tile.X, tile.Z, building.sizeX, building.sizeZ);
                building.Build(tile.transform.position);
                building = null;
                CursorScript.instance.ChangeState(new CursorIdleState(), null);
            }
        }
    }

    public void TileEnter(TileScript tile)
    {
        if (building != null)
        {
            building.Move(tile.transform.position);
            if (building != null && TileManagerScript.instance.CanBeBuild(tile.X, tile.Z, building.sizeX, building.sizeZ) &&
            ResourceManagerScript.instance.CanBeBuild(building.gameObject.GetComponent<BuildingCostScript>().BuildingCost,
            building.gameObject.GetComponent<BuildingCostScript>().COINS_COST))
            {
                building.HighlightOnOff(false);
            }
            else
            {
                building.HighlightOnOff(true);
            }
        }
    }

    public void TileExit(TileScript tile)
    {

    }

    public void SecondButtonClick()
    {
        if (building != null)
        {
            building.Rotate();
        }
    }
}
