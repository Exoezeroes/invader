using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : Block
{
    public override void Start()
    {
        Id = 0;
        Name = "Air";
        MaxHealth = 1;

        base.Start();
    }
}
