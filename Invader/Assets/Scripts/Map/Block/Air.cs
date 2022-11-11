using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Block
{
    private const uint AIR_ID = 0;
    private const string AIR_NAME = "Air";
    private const float AIR_HEALTH = 1;

    protected override void Start()
    {
        Id = 0;
        Name = ToString();
        MaxHealth = 1;

        base.Start();
    }
    public override string ToString()
    {
        return "Air";
    }
}
