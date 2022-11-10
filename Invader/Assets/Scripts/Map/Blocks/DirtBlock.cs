using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBlock : Block, IBreakable
{
    public override void Start()
    {
        Id = 1;
        Name = "DirtBlock";
        MaxHealth = 3;

        base.Start();
    }

    public void Break(int damage)
    {
        ReduceHealth(damage);
    }
}
