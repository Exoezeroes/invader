﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] Player player;
    [SerializeField] Slider hpBar; // Health Point
    [SerializeField] Slider mpBar; // Mana Point
    [SerializeField] Slider spBar; // Stamina Point
    [SerializeField] TextMeshProUGUI hpText; // Health Point
    [SerializeField] TextMeshProUGUI mpText; // Mana Point
    [SerializeField] TextMeshProUGUI spText; // Stamina Point
#pragma warning restore 0649

    void Update()
    {
        hpBar.value = player.GetHp();
        mpBar.value = player.GetMp();
        spBar.value = player.GetSp();

        hpBar.maxValue = player.GetMaxHp();
        mpBar.maxValue = player.GetMaxMp();
        spBar.maxValue = player.GetMaxSp();
        
        hpText.text = "" + Mathf.Round(hpBar.value) + "/" + Mathf.Round(hpBar.maxValue);
        mpText.text = "" + Mathf.Round(mpBar.value) + "/" + Mathf.Round(mpBar.maxValue);
        spText.text = "" + Mathf.Round(spBar.value) + "/" + Mathf.Round(spBar.maxValue);
    }
}