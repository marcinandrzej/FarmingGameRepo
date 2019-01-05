using System;
using System.Collections;
using System.Collections.Generic;

public interface CursorStates
{
    void OnStateEnter(BuildingScript _building);
    void OnStateExit();
    void TileEnter(TileScript tile);
    void TileExit(TileScript tile);
    void TileClick(TileScript tile);
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
}

public class CursorBuildState : CursorStates
{
    private BuildingScript building;

    public void OnStateEnter(BuildingScript _building)
    {
        building = _building;
    }

    public void OnStateExit()
    {

    }

    public void TileClick(TileScript tile)
    {
        if (building != null && TileManagerScript.instance.CanBeBuild(tile.X, tile.Z, building.sizeX, building.sizeZ))
        {
            TileManagerScript.instance.OcuppyTiles(building.gameObject, tile.X, tile.Z, building.sizeX, building.sizeZ);
            building.Build(tile.transform.position);
            building = null;
        }
    }

    public void TileEnter(TileScript tile)
    {
        if(building != null)
            building.Move(tile.transform.position);
    }

    public void TileExit(TileScript tile)
    {

    }
}
