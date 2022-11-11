using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    protected Grid Grid { get; private set; }

    public void CreateGrid(int width, int height)
    {
        Grid = new Grid(width, height);
    }
}
