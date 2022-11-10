using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private Block[,] blockArray;

    public Grid(int width, int height, float cellSize = 1)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        originPosition = Vector2.zero;

        blockArray = new Block[width, height];
        FillAir();
        Debugger();
    }
    public Grid(int width, int height, Vector3 originPosition, float cellSize = 1)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        blockArray = new Block[width, height];
        FillAir();
    }

    private void Debugger()
    {
        for (int x = 0; x < blockArray.GetLength(0); x++)
        {
            for (int y = 0; y < blockArray.GetLength(1); y++)
            {
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
    }

    public void SetGridBlock(Vector3 worldPosition, Block block)
    {
        GetXY(worldPosition, out int x, out int y);
        SetGridBlock(x, y, block);
    }

    public void SetGridBlock(int x, int y, Block block)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            Object.Destroy(blockArray[x, y].gameObject);
            block.transform.position = new Vector2(x, y) + new Vector2 (cellSize, cellSize) * 0.5f;
            blockArray[x, y] = block;
        }
        else
        {
            Object.Destroy(block.gameObject);
        }
    }

    public Block GetBlockAt(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height)
        {
            return blockArray[x, y];
        }
        else
        {
            return default;
        }
    }
    public Block GetBlockAt(Vector3 worldPosition)
    {
        GetXY(worldPosition, out int x, out int y);
        return GetBlockAt(x, y);
    }

    public void FillAir()
    {
        for (int x = 0; x < blockArray.GetLength(0); x++)
        {
            for (int y = 0; y < blockArray.GetLength(1); y++)
            {
                GameObject NewGameObject = new GameObject("Air".ToString());
                Block Air = NewGameObject.AddComponent<Air>();
                Air.transform.position = new Vector2(x, y);
                blockArray[x, y] = Air;
            }
        }
    }
}
