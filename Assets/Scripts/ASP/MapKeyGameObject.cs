using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapKeyGameObject", menuName = "ASPMap/MapKey/MapKeyGameObject")]
public class MapKeyGameObject : MapKey
{
    public MapObjectKey<GameObject> dict;
}
