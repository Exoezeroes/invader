using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTester : MonoBehaviour
{
    private Grid Grid;

    private void Start()
    {
        Grid = new Grid(10, 10);
        AtlasLoader.LoadSprites("BlockAtlas");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Object = new GameObject("Dirt Block");
            Block DirtBlock = Object.AddComponent<DirtBlock>();
            Grid.SetGridBlock(Util.GetMouseWorldPosition2D(), DirtBlock);
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameObject Object = new GameObject("Air");
            Block Air = Object.AddComponent<Air>();
            Grid.SetGridBlock(Util.GetMouseWorldPosition2D(), Air);
        }
    }
}
