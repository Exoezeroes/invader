using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthManipulator : MonoBehaviour
{
    [SerializeField] float hpAmount;
    [SerializeField] float mpAmount;
    [SerializeField] float spAmount;
    void OnCollisionEnter2D(Collision2D col)
    {
        playerManager player = col.gameObject.GetComponent<playerManager>();
        player.hp += hpAmount;
        player.mp += mpAmount;
        player.sp += spAmount;
        if (player.hp > player.maxHp)
        {
            player.hp = player.maxHp;
        }
        if (player.mp > player.maxMp)
        {
            player.mp = player.maxMp;
        }
        if (player.sp > player.maxSp)
        {
            player.sp = player.maxSp;
        }
    }
}
