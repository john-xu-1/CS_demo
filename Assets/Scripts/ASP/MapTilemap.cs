using System.Collections;
using System.Collections.Generic;
using Clingo;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapTilemap : ASPMap
{
    public Tilemap mapWall;

    public Tilemap mapBG;

    public TileBase bg;

    public override void DisplayMap(AnswerSet answerset, MapKey mapKey)
    {
        foreach (List<string> widths in answerset.Value[mapKey.widthKey])
        {
            if (int.Parse(widths[0]) > width) width = int.Parse(widths[0]);
        }
        foreach (List<string> h in answerset.Value[mapKey.heightKey])
        {
            if (int.Parse(h[0]) > height) height = int.Parse(h[0]);
        }

        int typeIndex = mapKey.typeIndex;
        int xIndex = mapKey.xIndex;
        int yIndex = mapKey.yIndex;

        foreach (List<string> tileASP in answerset.Value[mapKey.typeKey])
        {
            int x = int.Parse(tileASP[xIndex]) - 1;
            int y = int.Parse(tileASP[yIndex]) - 1;

            TileBase tile = ((MapKeyTileBase)mapKey).dict[tileASP[typeIndex]];
            if (tile == bg) mapBG.SetTile(new Vector3Int(x, y, 0), tile);
            else mapWall.SetTile(new Vector3Int(x, y, 0), tile);
        }
    }
}