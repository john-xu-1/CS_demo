using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "MapKeyTileBase", menuName = "ASPMap/MapKey/MapKeyTileBase")]
public class MapKeyTileBase : MapKey
{
    public MapObjectKey<TileBase> dict;
}
