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
        if (Input.GetMouseButton(0))
        {
            GameObject Object = new GameObject("Dirt Block");
            Block DirtBlock = Object.AddComponent<DirtBlock>();
            Grid.SetGridBlock(Util.GetMouseWorldPosition2D(), DirtBlock);
        }

        if (Input.GetMouseButton(1))
        {
            GameObject Object = new GameObject("StoneBlock");
            Block StoneBlock = Object.AddComponent<StoneBlock>();
            Grid.SetGridBlock(Util.GetMouseWorldPosition2D(), StoneBlock);
        }

        if (Input.GetMouseButton(2))
        {
            GameObject Object = new GameObject("Air");
            Block Air = Object.AddComponent<Air>();
            Grid.SetGridBlock(Util.GetMouseWorldPosition2D(), Air);
        }
    }
}
