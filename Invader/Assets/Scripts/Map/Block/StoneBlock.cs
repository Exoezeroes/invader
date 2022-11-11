using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBlock : Block, IBreakable, ICollidable
{
    private const uint STONE_ID = 2;
    private const string STONE_NAME = "StoneBlock";
    private const float STONE_HEALTH = 4;

    protected override void Start()
    {
        Id = STONE_ID;
        Name = STONE_NAME;
        MaxHealth = STONE_HEALTH;

        base.Start();
        GenerateCollider();
    }
    public void Break(int damage)
    {
        ReduceHealth(damage);
    }
    public override string ToString()
    {
        return STONE_NAME;
    }
    public void GenerateCollider()
    {
        CreateCollider();
    }
}
