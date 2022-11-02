using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Attributes
        // Health Point
    [SerializeField] private float hp = 100;
    [SerializeField] private float maxHp = 100;
        // Mana Point
    [SerializeField] private float mp = 10; 
    [SerializeField] private float maxMp = 10;
        // Stamina Point
    [SerializeField] private float sp = 100;
    [SerializeField] private float maxSp = 100;
        // Statuses
    [SerializeField] private bool isAlive = true;
    
    // Getters
    public float GetHp() {return hp;}
    public float GetMaxHp() {return maxHp;}
    public float GetMp() {return mp;} 
    public float GetMaxMp() {return maxMp;}
    public float GetSp() {return sp;}
    public float GetMaxSp() {return maxSp;}
    public bool GetStatus() {return isAlive;}

    // Methods
    public void HealHp(float val)
    {
        hp += val;
        if (hp > maxHp) {hp = maxHp;}
    }

    public void HealMp(float val)
    {
        mp += val;
        if (mp > maxMp) {mp = maxMp;}
    }

    public void HealSp(float val)
    {
        sp += val;
        if (sp > maxSp) {sp = maxSp;}
    }

    public void ModifyMaxHp(float val) {maxHp += val;}
    public void ModifyMaxMp(float val) {maxMp += val;}
    public void ModifyMaxSp(float val) {maxSp += val;}

    // Game Functions
    void Update()
    {
        if (hp <= 0) {isAlive = false;}
    }
}
