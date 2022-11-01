using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hudScript : MonoBehaviour
{
    [SerializeField] playerManager player;
    [SerializeField] Slider hpBar; // Health Point
    [SerializeField] Slider mpBar; // Mana Point
    [SerializeField] Slider spBar; // Stamina Point
    [SerializeField] TextMeshProUGUI hpText; // Health Point
    [SerializeField] TextMeshProUGUI mpText; // Mana Point
    [SerializeField] TextMeshProUGUI spText; // Stamina Point

    void Update()
    {
        hpBar.value = player.hp;
        mpBar.value = player.mp;
        spBar.value = player.sp;
        hpText.text = "" + Mathf.Round(player.hp) + "/" + Mathf.Round(hpBar.maxValue);
        mpText.text = "" + Mathf.Round(player.mp) + "/" + Mathf.Round(mpBar.maxValue);
        spText.text = "" + Mathf.Round(player.sp) + "/" + Mathf.Round(spBar.maxValue);
    }
}
