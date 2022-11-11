using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBlock : Block, IBreakable, ICollidable
{
    private const uint DIRT_ID = 1;
    private const string DIRT_NAME = "DirtBlock";
    private const float DIRT_HEALTH = 3;
    protected override void Start()
    {
        Id = DIRT_ID;
        Name = DIRT_NAME;
        MaxHealth = DIRT_HEALTH;

        base.Start();
        GenerateCollider();
    }
    public void Break(int damage)
    {
        ReduceHealth(damage);
    }
    public override string ToString()
    {
        return DIRT_NAME;
    }
    public void GenerateCollider()
    {
        CreateCollider();
    }
}
