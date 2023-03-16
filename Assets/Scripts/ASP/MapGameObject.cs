using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGameObject : ASPMap
{
    //public Vector2 offset;
    private GameObject[,] map;
    public GameObject player;

    override public void DisplayMap(Clingo.AnswerSet answerset, MapKey mapKey)
    {
        DisplayMap(answerset, mapKey.widthKey, mapKey.heightKey, mapKey.typeKey, mapKey.xIndex, mapKey.yIndex, mapKey.typeIndex, ((MapKeyGameObject)mapKey).dict);
    }
    public void DisplayMap(Clingo.AnswerSet answerset, string widthKey, string heightKey, string typeKey, int xIndex, int yIndex, int typeIndex, MapObjectKey<GameObject> dict)
    {
        foreach (List<string> widths in answerset.Value[widthKey])
        {
            if (int.Parse(widths[0]) > width) width = int.Parse(widths[0]);
        }
        foreach (List<string> h in answerset.Value[heightKey])
        {
            if (int.Parse(h[0]) > height) height = int.Parse(h[0]);
        }

        map = new GameObject[width, height];

        foreach (List<string> tileASP in answerset.Value[typeKey])
        {
            int x = int.Parse(tileASP[xIndex]) - 1;
            int y = int.Parse(tileASP[yIndex]) - 1;

            string tileType = tileASP[typeIndex];

            //Debug.Log(tileType);

            GameObject p;

            if (tileType != "acceptor")
            {
                p = Instantiate(player);
                
            }
            else
            {
                p = Instantiate(dict[tileType]);
                
            }

            p.transform.position = new Vector3(x * tileSpacing + offset.x, y * tileSpacing + offset.y);



            //    GameObject tile = Instantiate(dict[tileType]);
            //    tile.transform.position = new Vector3(x * tileSpacing + offset.x, y * tileSpacing + offset.y);
        }
    }
}
