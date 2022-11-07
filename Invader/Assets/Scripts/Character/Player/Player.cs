using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ACharacter
{
    // Attributes
        // HP
    [SerializeField] private float baseRegenHP;             // flat amount
    [SerializeField] private float regenPercentHP;          // percentage of max
    [SerializeField] private float regenMultiplierHP;       // ratio of current to max
    [SerializeField] private float regenFactorHP;           // factor of multiplier (big => good)
    [SerializeField] private float minMultiplierRegenHP;    // minimum ratio
    [SerializeField] private float maxMultiplierRegenHP;    // maximum ratio
        // MP
    [SerializeField] private float baseRegenMP;
    [SerializeField] private float regenPercentMP;
    [SerializeField] private float regenMultiplierMP;
    [SerializeField] private float regenFactorMP;
    [SerializeField] private float minMultiplierRegenMP;
    [SerializeField] private float maxMultiplierRegenMP;
        // SP
    [SerializeField] private float baseRegenSP;
    [SerializeField] private float regenPercentSP;
    [SerializeField] private float regenMultiplierSP;
    [SerializeField] private float regenFactorSP;
    [SerializeField] private float minMultiplierRegenSP;
    [SerializeField] private float maxMultiplierRegenSP;

    // Setters
    public void SetRegenMultiplierHP(float multiplier)
    {
        if (multiplier < minMultiplierRegenHP) { regenMultiplierHP = minMultiplierRegenHP; }
        else if (multiplier > maxMultiplierRegenHP) { regenMultiplierHP = maxMultiplierRegenHP; }
        else { regenMultiplierHP = multiplier; }
    }

    public void SetRegenMultiplierMP(float multiplier)
    {
        if (multiplier < minMultiplierRegenMP) { regenMultiplierMP = minMultiplierRegenMP; }
        else if (multiplier > maxMultiplierRegenMP) { regenMultiplierMP = maxMultiplierRegenMP; }
        else { regenMultiplierMP = multiplier; }
    }

    public void SetRegenMultiplierSP(float multiplier)
    {
        if (multiplier < minMultiplierRegenSP) { regenMultiplierSP = minMultiplierRegenSP; }
        else if (multiplier > maxMultiplierRegenSP) { regenMultiplierSP = maxMultiplierRegenSP; }
        else { regenMultiplierSP = multiplier; }
    }

    // Methods
    private void Regenerate()
    {
        CalculateBase();
        CalculateMultiplier();

        float regenAmountHP = baseRegenHP * regenMultiplierHP * Time.deltaTime;
        float regenAmountMP = baseRegenMP * regenMultiplierMP * Time.deltaTime;
        float regenAmountSP = baseRegenSP * regenMultiplierSP * Time.deltaTime;
        HealHP(regenAmountHP);
        HealMP(regenAmountMP);
        HealSP(regenAmountSP);
    }

    private void CalculateBase()
    {
        baseRegenHP = regenPercentHP * GetMaxHP();
        baseRegenMP = regenPercentMP * GetMaxMP();
        baseRegenSP = regenPercentSP * GetMaxSP();
    }

    private void CalculateMultiplier()
    {
        if (regenMultiplierHP < maxMultiplierRegenHP) { SetRegenMultiplierHP(regenFactorHP * GetHP() / GetMaxHP()); }
        if (regenMultiplierMP < maxMultiplierRegenMP) { SetRegenMultiplierMP(regenFactorMP * GetMP() / GetMaxMP()); }
        if (regenMultiplierSP < maxMultiplierRegenSP) { SetRegenMultiplierSP(regenFactorSP * GetSP() / GetMaxSP()); }
    }

    // Fuctions
    private void Start()
    {
        // percentage of max
        regenPercentHP = 0.1f;
        regenPercentMP = 0.08f;
        regenPercentSP = 0.3f;

        // factor of multiplier (bigger -> faster)
        regenFactorHP = 0.8f;
        regenFactorMP = 0.8f;
        regenFactorSP = 0.85f;

        // minimum ratio
        minMultiplierRegenHP = 0.05f;
        minMultiplierRegenMP = 0.025f;
        minMultiplierRegenSP = 0.15f;

        // maximum ratio
        maxMultiplierRegenHP = 0.8f;
        maxMultiplierRegenMP = 0.8f;
        maxMultiplierRegenSP = 0.9f;

        // flat amount
        CalculateBase();

        // ratio of current to max
        CalculateMultiplier();
    }
    private void FixedUpdate()
    {
        if (GetHP() < GetMaxHP() || GetMP() < GetMaxMP() || GetSP() < GetMaxSP())
        {
            Regenerate();
        }
    }
}
